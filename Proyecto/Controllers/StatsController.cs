using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    [Route("/Account/[controller]")]
    public class StatsController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            ViewBag.SecondaryLayout = "_StatsLayout";
            ViewBag.CurrentView = "Stats_Index";
            ViewBag.SecView = "Stats_Index";
            return View();
        }
        [HttpGet("[action]")]
        public IActionResult Saves()
        {
            ViewBag.SecondaryLayout = "_StatsLayout";
            ViewBag.CurrentView = "Stats_Index";
            ViewBag.SecView = "Stats_Saves";
            return View();
        }
    }
}
