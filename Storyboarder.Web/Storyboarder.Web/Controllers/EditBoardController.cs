using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Storyboarder.Web.DAL;
using Storyboarder.Web.Models;

namespace Storyboarder.Web.Controllers
{
    public class EditBoardController : Controller
    {

        #region Dependency Injection
        // Dependency injection configuration
        private readonly IBoardDAL dal;
        public EditBoardController(IBoardDAL dal)
        {
            this.dal = dal;
        }
        #endregion

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
        /// <returns>Doesn't return anything, but updates the database.</returns>
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

    }
}