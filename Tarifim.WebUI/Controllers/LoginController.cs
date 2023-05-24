using Microsoft.AspNetCore.Mvc;

namespace Tarifim.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
