using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Tarifim.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "admin")]

    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }


    }
}
