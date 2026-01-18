using System.ComponentModel.DataAnnotations;

namespace asp.net_tuto_03.Models.Auth
{
    public class Auth
    {
    }

    public class Register
    {
        public Register()
        {
        }

        public Register(string email, string password, string confrimPassword)
        {
            Email = email;
            Password = password;
            ConfrimPassword = confrimPassword;
        }

        [Required(ErrorMessage ="Email Field Is Required!")]
        [EmailAddress(ErrorMessage ="Email must be real email format!")]
        public string? Email { get; set; }

        [Required]
        [StringLength(50,MinimumLength =6,ErrorMessage ="Password must be between 6 and 50")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        public string? ConfrimPassword { get; set; }
    }
}
