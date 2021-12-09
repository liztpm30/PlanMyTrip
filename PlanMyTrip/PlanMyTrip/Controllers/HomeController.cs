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

namespace PlanMyTrip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITripRepository _repository;
        private readonly IConfiguration _config;


        public HomeController(ILogger<HomeController> logger, ITripRepository repository, IConfiguration configuration)
        {
            _logger = logger;
            this._repository = repository;
            this._config = configuration;

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

        public IActionResult History ()
        {
            var record = _repository.GetUserItineraries(4);
            var record2 = _repository.GetItineraries(record);

            return View(record2);
        }

        public IActionResult NewItinerary()
        {
            //pass API key
            var apiKey = _config.GetValue<string>("GoogleApiKey");
            var apiUrl = $"https://maps.googleapis.com/maps/api/js?key={apiKey}&callback=initMap&v=weekly";
            ViewBag.apiUrl = apiUrl;

            return View();
        }


        [HttpPost]
        public IActionResult GenerateItinerary(int tripDuration, double lat, double lng, int miles, int maxPlaces, string tripName)
        {

            ViewBag.tripDuration = tripDuration;
            ViewBag.lat = lat;
            ViewBag.lng = lng;
            ViewBag.miles = miles;
            ViewBag.maxPlaces = maxPlaces;
            ViewBag.tripName = tripName;


            return View("EditItinerary");
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
