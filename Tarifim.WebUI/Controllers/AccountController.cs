using Microsoft.AspNetCore.Mvc;
using Tarifim.Business.Dtos;
using Tarifim.Business.Services;
using Tarifim.WebUI.Extensions;
using Tarifim.WebUI.Models;

namespace Tarifim.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Hesabim")]
        public IActionResult Index()
        {
            var viewModel = new AccountViewModel()
            {
                Name = User.GetUserName(),
                SurName = User.GetUserSurName(),
                Email = User.GetUserEmail(),
                
            };

            return View(viewModel);
            
        }

        [HttpPost]
        [Route("Hesabim")]
        public IActionResult Update(AccountViewModel formData)
        {
            if (!ModelState.IsValid) 
            {
                return View("Index",formData);
            }

            var UserProfil = new UserProfilDto()
            {
                Id = User.GetUserId(),
                Name = formData.Name,
                SurName = formData.SurName,
                Email = formData.Email,
            };
            _userService.updateUser(UserProfil);
            return View("Index","Home");
        }
    }
}
