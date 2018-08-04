using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Storyboarder.Web.DAL;
using Storyboarder.Web.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Storyboarder.Web.Controllers
{
    [Route("api/boards")]
    [ApiController]
    public class HomeApiController : Controller
    {
        #region Dependency Injection
        // Dependency injection configuration
        private readonly IBoardDAL dal;
        public HomeApiController(IBoardDAL dal)
        {
            this.dal = dal;
        }
        #endregion

        /// <summary>
        /// Gets all the boards from the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Board>> GetAllBoards()
        {
            return dal.GetAllBoards().ToList();
        }
    }
}
