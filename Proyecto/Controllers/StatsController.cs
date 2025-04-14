using Microsoft.AspNetCore.Mvc;
using Proyecto.Models.User;
using Proyecto.Extensions;

namespace Proyecto.Controllers
{
    // Controlador de las Stats
    [Route("/Account/[controller]")]
    public class StatsController : Controller
    {
        // Accede al Index de Stats con los datos del Usuario en sesion y establece la visualizacion de el Index.
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            var userModel = HttpContext.Session.GetObject<UserViewModel>("UserModel");
            ViewBag.SecondaryLayout = "_StatsLayout";
            ViewBag.CurrentView = "Stats_Index";
            ViewBag.SecView = "Stats_Index";
            return View(/*Object for Tests new UserViewModel()*/userModel);
        }
        // Accede a la pagina de archivos de guardado con los datos del Usuario en sesion y establece la visualizacion de esta pagina.
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
