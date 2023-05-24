using Microsoft.AspNetCore.Mvc;
using Tarifim.Business.Services;
using Tarifim.WebUI.Models;

namespace Tarifim.WebUI.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

       
        public IActionResult Index()
        {
            var categoryDto = _categoryService.GetCategories();

            var ViewModel = categoryDto.Select(x => new CategoryListModel
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath=x.CategoryImage,
            }).ToList();

            return View(ViewModel);
        }
    }
}
