using Microsoft.AspNetCore.Mvc;
using Proyecto.Models.User;
using Proyecto.Extensions;

namespace Proyecto.Controllers
{
    [Route("/Account/[controller]")]
    public class StatsController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            var userModel = HttpContext.Session.GetObject<UserViewModel>("UserModel");
            ViewBag.SecondaryLayout = "_StatsLayout";
            ViewBag.CurrentView = "Stats_Index";
            ViewBag.SecView = "Stats_Index";
            return View(/*Object for Tests new UserViewModel()*/userModel);
        }
        [HttpGet("[action]")]
        public IActionResult Saves()
        {
            var userModel = HttpContext.Session.GetObject<UserViewModel>("UserModel");
            ViewBag.SecondaryLayout = "_StatsLayout";
            ViewBag.CurrentView = "Stats_Index";
            ViewBag.SecView = "Stats_Saves";
            return View(/*Object for Tests new UserContent()*/ userModel.UserContent);
        }
    }
}
