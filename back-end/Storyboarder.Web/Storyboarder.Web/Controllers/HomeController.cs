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
        
        // Dependency injection configuration
        private readonly IBoardDAL dal;
        public HomeController(IBoardDAL dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var boards = dal.GetAllBoards();

            return View(boards);
        }

        [HttpGet]
        public IActionResult EditBoard(int id)
        {
            var board = dal.GetBoard(id);

            return View(board);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBoard(Board board)
        {
            dal.UpdateBoard(board);

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBoard(int id)
        {
            dal.DeleteBoard(id);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
