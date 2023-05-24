using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tarifim.WebUI.Areas.Admin.Models
{
    public class FoodListViewModel
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Content { get; set; }

       
        public string Description { get; set; }

        
        public string CategoryName { get; set; }

       
        public string FoodImage { get; set; }
    }
}
