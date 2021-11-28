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

namespace PlanMyTrip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITripRepository _repository;

        public HomeController(ILogger<HomeController> logger, ITripRepository repository)
        {
            _logger = logger;
            this._repository = repository;
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
            return View();
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
