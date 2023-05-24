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
    public class FoodManager : IFoodService
    {
        private readonly IRepository<FoodEntity> _foodRepository;
        private readonly ICategoryService _categoryService;

        public FoodManager(IRepository<FoodEntity> foodRepository, ICategoryService categoryService)
        {
            _foodRepository = foodRepository;
            _categoryService = categoryService;
        }
        public ServiceMessage AddFood(FoodDto foodDto)
        {
            var hasFood = _foodRepository.GetAll(x => x.Name.ToLower() == foodDto.Name.ToLower() && x.IsDeleted == false).ToList();

            if (hasFood.Any())
            {
                return new ServiceMessage()
                {
                    IsSucceed = false,
                    Message = "Zaten böyle bir yemek kayıdı mevcut!!!"
                };
            }

            var foodEntity = new FoodEntity()
            {
                Id = foodDto.Id,
                Name = foodDto.Name,
                Content = foodDto.Content,
                Description = foodDto.Description,
                ImagePath = foodDto.FoodImage,
                CategoryId = foodDto.CategoryId
            };
            _foodRepository.Add(foodEntity);

            return new ServiceMessage()
            {
                IsSucceed = true,
            };
        }

        public void DeleteFood(int id)
        {
            _foodRepository.Delete(id);
        }

        public FoodDetailDto GetFoodDetail(int id)
        {
            var foodEntity = _foodRepository.GetById(id);

            var categoryEntity=_categoryService.GetCategoryId(foodEntity.CategoryId);

            var detailDto = new FoodDetailDto()
            {
                Name = foodEntity.Name,
                Content = foodEntity.Content,
                Description = foodEntity.Description,
                ImagePath = foodEntity.ImagePath,
                CategoryName = categoryEntity.Name,
                ModifiedDate= foodEntity.ModifiedDate,
            };
            return detailDto;
        }

        public FoodDto GetFoodId(int id)
        {
            var foodEntity = _foodRepository.GetById(id);

            var foodDto = new FoodDto()
            {
                Id = foodEntity.Id,
                Name = foodEntity.Name,
                Content = foodEntity.Content,
                Description = foodEntity.Description,
                CategoryId = foodEntity.CategoryId,
                FoodImage = foodEntity.ImagePath
            };
            return foodDto;
        }

        public List<FoodDto> GetFoods(int? id)
        {
            IOrderedQueryable<FoodEntity> foodEntities;
            if (id != null)
            {
                foodEntities = _foodRepository.GetAll(x => x.IsDeleted == false).Where(x => x.CategoryId == id).OrderBy(x => x.Category.Name).ThenBy(x => x.Name);
            }
            else
            {
                foodEntities = _foodRepository.GetAll(x => x.IsDeleted == false).OrderBy(x => x.Category.Name).ThenBy(x => x.Name);
            }

            var foodList = foodEntities.Select(x => new FoodDto
            {
                Id = x.Id,
                Name = x.Name,
                Content = x.Content,
                Description = x.Description,
                CategoryId = x.CategoryId,
                FoodImage = x.ImagePath,
                CategoryName = x.Category.Name
            }).ToList();

            return foodList;
        }

        public void UpdateFood(FoodDto foodDto)
        {
            var foodEntity = _foodRepository.GetById(foodDto.Id);

            foodEntity.Name = foodDto.Name;
            foodEntity.Content = foodDto.Content;
            foodEntity.Description = foodDto.Description;
            foodEntity.CategoryId = foodDto.CategoryId;

            if (foodDto.FoodImage != null)
            {
                foodEntity.ImagePath = foodDto.FoodImage;
            }

            _foodRepository.Update(foodEntity);
        }
    }
}
