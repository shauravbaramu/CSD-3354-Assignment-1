using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class User
    {
        [Required]
        // User model with required fields
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 and less than 20.")]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Password and Confirm Message doesn't match.")]
        public string ConfirmPassword { get; set; }
        public string? Phone { get; set; }
        
        public User? isCredentialMatch(List<User> Users)
        {
            foreach (var user in Users)
            {
                if (user.Email == Email && user.Password == Password)
                {
                    return user;
                }
            }
            return null;
        }

    }
}
