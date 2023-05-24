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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

      
        public IActionResult List()
        {
            var categoryList = _categoryService.GetCategories();
            var viewModel=categoryList.Select(x=> new CategoryListViewModel
            {
                Id=x.Id,
                Name=x.Name,
                CategoryImage =x.CategoryImage,
            }).ToList();
            return View( viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Form",new CategoryFormViewModel());
        }

        [HttpPost]
        public IActionResult Add(CategoryFormViewModel formData) 
        {
            if (!ModelState.IsValid)
            {
                return View("form",formData);

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

                var folderPath = Path.Combine("images", "categories");
                var wwwRootFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
                var wwwRootFilePath = Path.Combine(wwwRootFolderPath, fileName);

                Directory.CreateDirectory(wwwRootFolderPath);

                using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
                {
                    formData.File.CopyTo(fileStream);
                }

            }

            var categoryDto = new CategoryDto()
            {
                Id = formData.Id,
                Name = formData.Name,
                CategoryImage=fileName
            };

            if (formData.Id == 0)
            {
                var categoryControl = _categoryService.AddCategory(categoryDto);

                if (categoryControl.IsSucceed)
                {
                    return RedirectToAction("list", "Category");
                   
                }
                else
                {
                    ViewBag.ErrorMessage = categoryControl.Message;
                    return View("Form", formData);
                }
            }

            else 
            {
                _categoryService.UpdateCategory(categoryDto);
               
            }
          
            return RedirectToAction("List");

        }

        [HttpGet]
        public IActionResult Update(int id) 
        {
            var categoryDto=_categoryService.GetCategoryId(id);

            var viewModel = new CategoryFormViewModel()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
            };
            ViewBag.CategoryImage = categoryDto.CategoryImage;
           

            return View("Form",viewModel);
        }

        public IActionResult Delete(int id) 
        {
            _categoryService.DeleteCategory(id);
           
            return RedirectToAction("List");
        }
    }
}
