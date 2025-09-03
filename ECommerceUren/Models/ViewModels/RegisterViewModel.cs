using System.ComponentModel.DataAnnotations;

namespace ECommerceUren.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="First Name field must not be empty.")]
        [MinLength(3, ErrorMessage = "First name must be at least contain 3 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name field must not be empty")]
        [MinLength(3, ErrorMessage = "Last name must be at least contain 3 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email field must not be empty.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field must not be empty.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least contain 8 characters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password field must not be empty.")]
        [Compare("Password", ErrorMessage = "Password and confirm password id not mached.")]
        [MinLength(8, ErrorMessage = "Password must be at least contain 8 characters.")]
        public string ConfirmPassword { get; set; }
    }
}
