using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tarifim.WebUI.Areas.Admin.Models
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }

        
        public string Name { get; set; }


        public string CategoryImage { get; set; }
    }
}
