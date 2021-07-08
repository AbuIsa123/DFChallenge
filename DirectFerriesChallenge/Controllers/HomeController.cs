using DirectFerriesChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectFerriesChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserVM userVM)
        {
            return RedirectToAction("WelcomeUser", "Home", userVM );
        }

        public ActionResult WelcomeUser(UserVM userVM)
        {
            userVM.GetFirstName();
            userVM.GetNumberOfVowels();
            userVM.GetAge();
            userVM.GetDaysTillNextBirthday();
            userVM.GetDates();
            return View(userVM);
        }       
    }
}