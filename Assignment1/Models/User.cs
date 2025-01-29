using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class User
    {

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
       
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string? Phone { get; set; }

        public bool requiredValidation()
        {
            if(string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Email))
            {
                return false;
            } else
            {
                return true;
            }
        }

        public bool isPasswordConfirmed()
        {
            return Password == ConfirmPassword ? true : false;
        }

        public bool passwordValidation()
        {
            return Password.Length > 6 ? true : false;
        }

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
