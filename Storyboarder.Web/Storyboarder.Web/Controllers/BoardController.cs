using Microsoft.AspNetCore.Mvc;
using Storyboarder.Web.DAL;
using Storyboarder.Web.Models;
using Storyboarder.Web.Providers.Auth;
using System.Collections.Generic;

namespace Storyboarder.Web.Controllers
{
    public class BoardController : Controller
    {
        #region Dependency Injection
        // Dependency injection configuration
        private readonly IBoardDAL boardDal;
        private readonly IAuthProvider authProvider;

        public BoardController(IBoardDAL boardDal, IAuthProvider authProvider)
        {
            this.boardDal = boardDal;
            this.authProvider = authProvider;
        }
        #endregion

        /// <summary>
        /// Gets all boards that are associated with a particular user and displays them on the page.
        /// </summary>
        /// <returns>View with all the boards that are associted with a particular user.</returns>
        [HttpGet]
        [AuthorizationFilter]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AuthorizationFilter]
        public JsonResult GetBoardsForUser()
        {
            IList<Board> boards = new List<Board>();

            User currentUser = authProvider.GetCurrentUser();

            boards = boardDal.GetAllBoardsForUser(currentUser.Id);

            return Json(boards);
        }
    }
}