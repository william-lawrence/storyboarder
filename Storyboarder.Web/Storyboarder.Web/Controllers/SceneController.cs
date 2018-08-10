using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Storyboarder.Web.Controllers
{
    public class SceneController : Controller
    {
        public IActionResult DisplayScenes(int id)
        {
            return View();
        }
    }
}