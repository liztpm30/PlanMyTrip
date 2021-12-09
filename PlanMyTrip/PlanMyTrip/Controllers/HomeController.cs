using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanMyTrip.Models;
using PlanMyTrip.Data;
using PlanMyTrip.Data.Entities;
using Microsoft.Extensions.Configuration;
using PlanMyTrip.Services;
using PlanMyTrip.Models.Queries;
using PlanMyTrip.Models.Places;
using PlanMyTrip.Models.Responses;

namespace PlanMyTrip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITripRepository _repository;
        private readonly IConfiguration _config;

        private readonly IGooglePlaceApi _googlePlaceApi;


        public HomeController(ILogger<HomeController> logger, ITripRepository repository, IConfiguration configuration, IGooglePlaceApi api)
        {
            _logger = logger;
            this._repository = repository;
            this._config = configuration;
            this._googlePlaceApi = api;
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult History(string username)
        {
            var user = _repository.GetUserByUsername(username);
            var useritineraries = _repository.GetUserItineraries(user.First().Id);

            List<Itinerary> list = new List<Itinerary>();
            foreach (UserItinerary userItinerary in useritineraries)
            {
                var itinerary = _repository.GetUserItinerarybyID(user.First().Id, userItinerary.Id);
                list.Add(itinerary.Itinerary);
            }

            return View(list);
        }

        public IActionResult NewItinerary()
        {
            //pass API key
            var apiKey = _config.GetValue<string>("GoogleApiKey");
            var apiUrl = $"https://maps.googleapis.com/maps/api/js?key={apiKey}&callback=initMap&v=weekly";
            ViewBag.apiUrl = apiUrl;

            return View();
        }


        private HashSet<string> VacationBox = new HashSet<string> { "museum", "theme park", "restaurant", "park", "beach" };
        [HttpPost]
        public async Task<IActionResult> GenerateItinerary(string formUserName, int tripDuration, double lat, double lng, int miles, int maxPlaces, string tripName)
        {
            //pass API key
            var apiKey = _config.GetValue<string>("GoogleApiKey");
            var apiUrl = $"https://maps.googleapis.com/maps/api/js?key={apiKey}&callback=initAutocomplete&v=weekly&libraries=places";
            ViewBag.apiUrl = apiUrl;

            
            ViewBag.tripDuration = tripDuration;
            ViewBag.lat = lat;
            ViewBag.lng = lng;
            ViewBag.miles = miles;
            ViewBag.maxPlaces = maxPlaces;
            ViewBag.tripName = tripName;


            Itinerary itinerary = new Itinerary();
            itinerary.TripName = ViewBag.tripName;
            itinerary.LastUpdatedDate = DateTime.Now.Ticks;
            itinerary.NumberOfDays = ViewBag.tripDuration;
            
            LinkedList<PlaceItinerary> itineraries = new LinkedList<PlaceItinerary>();
            NearbyPlaceQuery nearbyPlaceQuery = new NearbyPlaceQuery(new Coordinates{Latitude = ViewBag.lat, Longitude = ViewBag.lng}.ToString());
            var responses = await GetNearbyPlaces(nearbyPlaceQuery);
            
            int days = 0;
            int locations = 0;
            int index = 0;
            int box = 0;
            HashSet<string> ids = new HashSet<string>();
            while (days < ViewBag.tripDuration && locations < ViewBag.maxPlaces)
            {
                if (index >= responses.Results.Count)
                {
                    if (box < VacationBox.Count)
                    {
                        nearbyPlaceQuery.Keyword = VacationBox.ElementAt(box++);
                        responses = await GetNearbyPlaces(nearbyPlaceQuery);
                        index = 0;
                    }
                    else 
                    {
                        break;
                    }
                }
                else
                {
                    var place = responses.Results[index++];
                    if (!ids.Contains(place.PlaceID))
                    {
                        itineraries.AddLast(new PlaceItinerary {
                            Place      = new Data.Entities.Place { GooglePlaceID = place.PlaceID, PlaceName = place.Name, Details = place.FormattedAddress },
                            PlaceIndex = locations+1,
                            DayNumber  = days+1
                        });
                        locations++;
                        ids.Add(place.PlaceID);
                        if (locations >= ViewBag.maxPlaces)
                        {
                            days++;
                            locations = 0;
                        }
                    }
                    else 
                    {
                        index++;
                    }
                }
            }
            itinerary.Places = itineraries;

            //get userId
            var user = _repository.GetUserByUsername(formUserName).FirstOrDefault();

            int id = _repository.AddItinerary(user.Id, itinerary);
            return await EditItinerary(id, 1, user.Id);
        }

        public async Task<IActionResult> EditItinerary(int itineraryid, int day, int userId)
        {
            var apiKey = _config.GetValue<string>("GoogleApiKey");
            var apiUrl = $"https://maps.googleapis.com/maps/api/js?key={apiKey}&callback=initAutocomplete&v=weekly&libraries=places";
            ViewBag.apiUrl = apiUrl;

            var db = _repository.GetUserItinerarybyID(userId, itineraryid).Itinerary.Places; 
            var forTheDay = db.Where(x => x.DayNumber == day);
            if (forTheDay != null && forTheDay.Count() > 0)
            {
                var placeDetails = new List<PlaceDetailResponse>();
                foreach (var activity in forTheDay)
                {
                    var detail = await GetPlaceDetails(activity.Place.GooglePlaceID); 
                    if (detail != null)
                    {
                        placeDetails.Add(detail);
                    }
                }
                ViewBag.places = placeDetails;
            }
            ViewBag.day = day;
            ViewBag.itineraryid = itineraryid;
            ViewBag.userId = userId;
            if (day <= 1) {
                ViewBag.prev = false;
            }
            else {
                ViewBag.prev = true;
            }

            if (day < db.Max(x => x.DayNumber))
            {
                ViewBag.next = true;
            }
            else {
                ViewBag.next = false;
            }
            return View("EditItinerary");
        }

        private async Task<PlaceDetailResponse> GetPlaceDetails(string googleid)
        {
            var apiKey = _config.GetValue<string>("GoogleApiKey");
            var placeDetailsQuery = new PlaceDetailsQuery(googleid);
            var response = await _googlePlaceApi.PlaceDetails(placeDetailsQuery, apiKey);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;
                return content;
            }
            return null;
        }

        private async Task<PlaceNearbyResponse> GetNearbyPlaces(NearbyPlaceQuery nearbyPlaceQuery)
        {
            var apiKey = _config.GetValue<string>("GoogleApiKey");
            var response = await _googlePlaceApi.NearbySearch(nearbyPlaceQuery, apiKey);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;
                return content;
            }

            return null;
        }



        [HttpGet]
        public async Task<FileResult> GetPlacePhoto(string? place)
        {
            if (place == null)
                return null;
            var apiKey = _config.GetValue<string>("GoogleApiKey");
            var photoQuery = new PlacePhotoQuery(place, 200, 200);
            var task = await _googlePlaceApi.PlacePhoto(photoQuery, apiKey);
            if (task.IsSuccessStatusCode)
            {
                var response = await task.Content.ReadAsByteArrayAsync();
                return File(response, "image/png");
            }
            return null;
        }

        [HttpPost]
        public void CreateUserRecord(string username, string uid)
        {
            User newUser = new User
            {
                Uid = uid,
                UserName = username
            };

            _repository.AddUser(newUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
