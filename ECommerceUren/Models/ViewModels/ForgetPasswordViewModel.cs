using System.ComponentModel.DataAnnotations;

namespace ECommerceUren.Models.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
