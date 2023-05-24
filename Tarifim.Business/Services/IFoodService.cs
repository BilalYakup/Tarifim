using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarifim.Business.Dtos;
using Tarifim.Business.Types;

namespace Tarifim.Business.Services
{
    public interface IFoodService
    {
        ServiceMessage AddFood(FoodDto foodDto);

        List<FoodDto> GetFoods(int? categoryId);

        FoodDto GetFoodId(int id);

        FoodDetailDto GetFoodDetail(int id);

        void UpdateFood(FoodDto foodDto);
        void DeleteFood(int id);

       
    }
}
