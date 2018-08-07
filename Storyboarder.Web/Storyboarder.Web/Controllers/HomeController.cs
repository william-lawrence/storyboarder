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
        /// <returns>View with all the boards the user has created.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var boards = dal.GetAllBoards();

            return View(boards);
        }

        /// <summary>
        /// Action that generate a page for the board when a user selects it.
        /// </summary>
        /// <param name="id">the id of the board in the database</param>
        /// <returns>View with the board that the user selected.</returns>
        [HttpGet]
        public IActionResult EditBoard(int id)
        {
            var board = dal.GetBoard(id);

            return View(board);
        }

        /// <summary>
        /// Updates the board with the changes that the user made.
        /// </summary>
        /// <param name="board">The updated board</param>
        /// <returns>Doens't return anything, but updates the database.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBoard(Board board)
        {
            dal.UpdateBoard(board);

            return NoContent();
        }

        /// <summary>
        /// Deletes the board that the user selected.
        /// </summary>
        /// <param name="id">The id in the database for the board to be deleted.</param>
        /// <returns>View of homepage.</returns>
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
