using System.ComponentModel.DataAnnotations;

namespace CSharpning.com.WebApp.ViewModels;

public class SignInViewModel
{
    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email Address Required")]
    [EmailAddress]
    public string Email { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password Address Required")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Your Password must be at least 8 characters")]
    public string Password { get; set; }

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}
