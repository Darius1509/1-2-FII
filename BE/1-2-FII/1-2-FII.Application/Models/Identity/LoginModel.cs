using System.ComponentModel.DataAnnotations;

namespace _1_2_FII.Application.Models.Identity
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
