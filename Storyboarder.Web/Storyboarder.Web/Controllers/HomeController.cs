using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Storyboarder.Web.DAL;
using Storyboarder.Web.Models;

namespace Storyboarder.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Dependency Injection
        // Dependency injection configuration
        private readonly IBoardDAL dal;
        public HomeController(IBoardDAL dal)
        {
            this.dal = dal;
        }
        #endregion

        /// <summary>
        /// Action that generates the homepage
        /// </summary>
        /// <returns>Home Page where the user can login</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Takes the user to the page where they can see information about the application.
        /// </summary>
        /// <returns>View for the about page.</returns>
        [HttpGet]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Takes the user to the page where they can reach out to me to report errors or other issues in the application
        /// </summary>
        /// <returns>View for the contact page</returns>
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
