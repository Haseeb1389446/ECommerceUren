using System.ComponentModel.DataAnnotations;

namespace ECommerceUren.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email field must not be empty.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field must not be empty.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least contain 8 characters.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
