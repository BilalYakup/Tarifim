using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarifim.Business.Dtos;
using Tarifim.Business.Services;
using Tarifim.Business.Types;
using Tarifim.Data.Entities;
using Tarifim.Data.Repositories;

namespace Tarifim.Business.Managers
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        public CategoryManager(IRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ServiceMessage AddCategory(CategoryDto categoryDto)
        {
            var category = _categoryRepository.GetAll(x => x.Name.ToLower() == categoryDto.Name.ToLower()&& x.IsDeleted==false).ToList();

            if (category.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu isimde kayıtlı yemek mevcut"
                };
            }

            var categoryEntity = new CategoryEntity()
            {
                Name = categoryDto.Name,
                ImagePath = categoryDto.CategoryImage
            };
            _categoryRepository.Add(categoryEntity);

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);

        }

        public List<CategoryDto> GetCategories()
        {
           var categoryEntities=_categoryRepository.GetAll(x=>x.IsDeleted==false).OrderBy(x=>x.Name).ToList();

            var categoryList = categoryEntities.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                CategoryImage = x.ImagePath,
            }).ToList();
            return categoryList;
        }

        public CategoryDto GetCategoryId(int id)
        {
            var categoryEntity= _categoryRepository.GetById(id);

            var categoryDto = new CategoryDto()
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                CategoryImage = categoryEntity.ImagePath,
            };
            return categoryDto;
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            var categoryEntity = _categoryRepository.GetById(categoryDto.Id);
            categoryEntity.Name = categoryDto.Name;
            categoryEntity.ImagePath = categoryDto.CategoryImage;
            _categoryRepository.Update(categoryEntity);
        }
    }
}
