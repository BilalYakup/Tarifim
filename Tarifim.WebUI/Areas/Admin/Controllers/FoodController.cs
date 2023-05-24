using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Tarifim.Business.Dtos;
using Tarifim.Business.Services;
using Tarifim.WebUI.Areas.Admin.Models;

namespace Tarifim.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "admin")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FoodController(IFoodService foodService,ICategoryService categoryService,
            IWebHostEnvironment webHostEnvironment)
        {
            _foodService = foodService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

       
        public IActionResult List()
        {
            var foodDtos=_foodService.GetFoods(null);

            var viewModel = foodDtos.Select(x => new FoodListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Content = x.Content,
                Description = x.Description,
                CategoryName = x.CategoryName,
                FoodImage = x.FoodImage,
            }).ToList();

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult NewFood() 
        {
            ViewBag.Categories=_categoryService.GetCategories();
            return View("Form",new FoodFormViewModel());
        }

        public IActionResult AddFood(FoodFormViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryService.GetCategories();
                return View("Form", formData);
            }
            var fileName = "";

            if (formData.File != null)
            {


                var allowedFileContentTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/jfif" };

                var allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".jfif" };


                var fileContentType = formData.File.ContentType;
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(formData.File.FileName);
                var fileExtension = Path.GetExtension(formData.File.FileName);

                

                if (!allowedFileContentTypes.Contains(fileContentType) ||
                        !allowedFileExtensions.Contains(fileExtension))
                {
                    ViewBag.FileError = "Lütfen jpg , jpeg , png veya jfif tipinde geçerli bir dosya yükleyiniz.";
                    ViewBag.Categories = _categoryService.GetCategories();
                    return View("form", formData);
                }

                fileName = fileNameWithoutExtension + "-" + Guid.NewGuid() + fileExtension;

                var folderPath = Path.Combine("images", "foods");
                var wwwRootFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
                var wwwRootFilePath = Path.Combine(wwwRootFolderPath, fileName);

                Directory.CreateDirectory(wwwRootFolderPath);

                using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
                {
                    formData.File.CopyTo(fileStream);
                }
               
            }

            if (formData.Id == 0)
            {
                var foodDto = new FoodDto()
                {
                    Id = formData.Id,
                    Name = formData.Name,
                    Content = formData.Content,
                    Description = formData.Description,
                    CategoryId = formData.CategoryId,
                    FoodImage = fileName
                };

                var response = _foodService.AddFood(foodDto);

                if (response.IsSucceed)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.ErrorMessage = response.Message;
                    ViewBag.Categories = _categoryService.GetCategories();
                    return View("Form", formData);
                }
            }
            else
            {
                var foodDto = new FoodDto()
                {
                    Id = formData.Id,
                    Name = formData.Name,
                    Content = formData.Content,
                    Description = formData.Description,
                    CategoryId = formData.CategoryId,
                    
                };
                if (formData.File != null)
                {
                    foodDto.FoodImage = fileName;
                }

                _foodService.UpdateFood(foodDto);
            }

            return RedirectToAction("List");
        }
        public IActionResult UpdateFood(int id)
        {
            var foodDto=_foodService.GetFoodId(id);

            var viewModel = new FoodFormViewModel()
            {
                Id = foodDto.Id,
                Name = foodDto.Name,
                Content = foodDto.Content,
                Description = foodDto.Description,
                CategoryId = foodDto.CategoryId,

            };
            ViewBag.Categories=_categoryService.GetCategories();
            ViewBag.FoodImage = foodDto.FoodImage;

            return View("Form", viewModel);
        }
        public IActionResult DeleteFood(int id) 
        {
            _foodService.DeleteFood(id);
            return RedirectToAction("List");
        }
    }
}
