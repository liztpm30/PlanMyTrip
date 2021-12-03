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

        public IActionResult Privacy()
        {
            return View();
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

        public IActionResult NewItinerary()
        {
            //pass API key
            var apiKey = _config.GetValue<string>("GoogleApiKey");
            var apiUrl = $"https://maps.googleapis.com/maps/api/js?key={apiKey}&callback=initMap&v=weekly";
            ViewBag.apiUrl = apiUrl;

            return View();
        }


        [HttpPost]
        public IActionResult GenerateItinerary(int tripDuration, bool sameArea, double lat, double lng, int miles, int maxPlaces, string tripName)
        {

            ViewBag.tripDuration = tripDuration;
            ViewBag.sameArea = sameArea;
            ViewBag.lat = lat;
            ViewBag.lng = lng;
            ViewBag.miles = miles;
            ViewBag.maxPlaces = maxPlaces;
            ViewBag.tripName = tripName;


            return View("EditItinerary");
        }



        //This is created temporary to show that the db records can be accessed and displayed on the view
        public IActionResult UserTest()
        {
            var dbRecords = _repository.GetAllUsers();

            return View(dbRecords);
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
