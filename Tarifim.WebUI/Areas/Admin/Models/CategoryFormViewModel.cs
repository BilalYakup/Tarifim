using System.ComponentModel.DataAnnotations;

namespace Tarifim.WebUI.Areas.Admin.Models
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Kategori Ad")]
        [Required(ErrorMessage ="Kategori adı girmek zorunludur")]
        public string Name { get; set; }

        [Display(Name = "Kategori Görseli")]
        public IFormFile? File { get; set; }
    }
}
