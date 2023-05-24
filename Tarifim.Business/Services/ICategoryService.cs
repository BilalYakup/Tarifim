using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarifim.Business.Dtos;
using Tarifim.Business.Types;

namespace Tarifim.Business.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();
        CategoryDto GetCategoryId(int id);

        ServiceMessage AddCategory(CategoryDto categoryDto);
        void UpdateCategory(CategoryDto categoryDto);
        void DeleteCategory(int id);
    }
}
