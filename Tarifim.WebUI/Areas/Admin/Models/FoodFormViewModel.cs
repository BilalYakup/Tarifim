using System.ComponentModel.DataAnnotations;

namespace Tarifim.WebUI.Areas.Admin.Models
{
    public class FoodFormViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Yemek Ad")]
        [Required(ErrorMessage ="Yemek adı girmek Zorunlu")]
        public string Name { get; set; }

        [Display(Name = "Malzemeler")]
        [Required(ErrorMessage = "Yemek İçeriği girmek Zorunlu")]
        public string Content { get; set; }

        [Display(Name = "Yapılış")]
        [Required(ErrorMessage = "Yemek Yapılışı girmek Zorunlu")]
        public string Description { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Yemek kategorisi girmek Zorunlu")]
        public int CategoryId { get; set; }

        [Display(Name = "Yemek Görseli")]
        public IFormFile? File { get; set; }
    }
}
