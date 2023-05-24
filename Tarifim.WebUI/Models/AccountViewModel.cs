

using System.ComponentModel.DataAnnotations;

namespace Tarifim.WebUI.Models
{
    public class AccountViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        public string SurName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        public string Email { get; set; }

    }
}
