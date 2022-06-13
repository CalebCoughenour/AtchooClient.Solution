using System.ComponentModel.DataAnnotations;

namespace AtchooClient.ViewModels
{
  public class LoginViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
  }
}