﻿using System;
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
        /// <returns>View with all the boards the user has created.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var boards = dal.GetAllBoards();

            return View(boards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
