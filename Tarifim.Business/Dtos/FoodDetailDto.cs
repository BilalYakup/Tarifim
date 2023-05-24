using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifim.Business.Dtos
{
    public class FoodDetailDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
