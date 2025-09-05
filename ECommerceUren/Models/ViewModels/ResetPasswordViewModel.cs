using System.ComponentModel.DataAnnotations;

namespace ECommerceUren.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least contain 8 characters.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least contain 8 characters.")]
        [Compare("Password", ErrorMessage = "Password and confirm password is not matched.")]
        public string ConfirmPassword { get; set; }

        public string ResetPasswordToken { get; set; }
    }
}
