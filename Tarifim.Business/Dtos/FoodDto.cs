using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifim.Business.Dtos
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string FoodImage { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
