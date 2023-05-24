using Microsoft.AspNetCore.Mvc;
using Tarifim.Business.Services;
using Tarifim.WebUI.Extensions;
using Tarifim.WebUI.Models;

namespace Tarifim.WebUI.Controllers
{
    public class FoodListController : Controller
    {
        private readonly IFoodService _foodService;

        public FoodListController(IFoodService foodService)
        {

            _foodService = foodService;
        }
        public IActionResult List(int? id)
        {
            var foodDto = _foodService.GetFoods(id);

            if (!User.IsLogged())
            {
                return RedirectToAction("Index", "Login");
            }

            var viewModel = foodDto.Select(x => new FoodListModel
            {
                Id = x.Id,
                Name = x.Name,
                CategoryName = x.CategoryName,
                ImagePath = x.FoodImage
            }).ToList();

            return View(viewModel);


        }


        public IActionResult Detail(int id)
        {
            var foodDetailDto = _foodService.GetFoodDetail(id);

            var viewModel = new FoodDetailModel()
            {
                Name = foodDetailDto.Name,
                Content = foodDetailDto.Content,
                Description = foodDetailDto.Description,
                ImagePath = foodDetailDto.ImagePath,
                CategoryName = foodDetailDto.CategoryName,
                ModifiedDate = foodDetailDto.ModifiedDate,
            };

            return View(viewModel);
        }
    }
}
