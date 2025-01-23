using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Password and Confirm password doesn't match!")]
        public string ConfirmPassword { get; set; }
        public string? Phone { get; set; }

        //public bool isPasswordConfirmed()
        //{
        //    bool passwordConfirmed = Password == ConfirmPassword ? true : false;

        //    return passwordConfirmed;
        //}

    }
}
