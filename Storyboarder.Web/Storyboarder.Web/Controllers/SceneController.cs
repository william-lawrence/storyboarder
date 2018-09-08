using Microsoft.AspNetCore.Mvc;
using Storyboarder.Web.DAL;
using Storyboarder.Web.Models;
using Storyboarder.Web.Providers.Auth;
using System.Collections;
using System.Collections.Generic;

namespace Storyboarder.Web.Controllers
{
    public class SceneController : Controller
    {
        #region Dependency Injection
        private readonly ISceneSqlDAL sceneDal;
        private readonly IAuthProvider authProvider;


        public SceneController(ISceneSqlDAL sceneDal, IAuthProvider authProvider)
        {
            this.sceneDal = sceneDal;
            this.authProvider = authProvider;
        }
        #endregion

        /// <summary>
        /// Get the view for the scene page with all the scenes and displays it to the user.
        /// </summary>
        /// <returns>The view for the scenes page</returns>
        [HttpGet]
        [AuthorizationFilter]
        public IActionResult Scenes()
        {
            IList scenes = new List<Scene>();
            User user = authProvider.GetCurrentUser();

            return View();
        }
    }
}