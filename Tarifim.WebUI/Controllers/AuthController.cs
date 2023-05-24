using Tarifim.Business.Dtos;
using Tarifim.Business.Services;
using Tarifim.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Tarifim.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
       
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var userDto = new UserDto()
            {
                Name = formData.Name.Trim(),
                SurName = formData.SurName.Trim(),
                Email = formData.Email.Trim(),
                Password = formData.Password.Trim(),
            };

            var response = _userService.addUser(userDto);

            if (response.IsSucceed)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                ViewBag.ErrorMessage = response.Message;
                return View(formData);
            }
        }

        public async Task<IActionResult> Login(LoginViewModel formData)
        {
            var loginDto = new LoginDto()
            {
                Email = formData.Email.Trim(),
                Password = formData.Password.Trim(),
            };

           var user=_userService.login(loginDto);

            if (user is null)
            {
                TempData["Message"] = "Email vaya şifre hatalı girdiniz.";
                
                return RedirectToAction("Index" , "Login");
                
            }
            

            var claims = new List<Claim>();
            
                claims.Add(new Claim("id", user.Id.ToString()));
                claims.Add(new Claim("name", user.Name));
                claims.Add(new Claim("surname", user.SurName));
                claims.Add(new Claim("email", user.Email));
                claims.Add(new Claim("usertype", user.UserType.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, user.UserType.ToString()));

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(12))
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);

            return RedirectToAction("index", "Home");

           
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "home");
        }


    }
}
