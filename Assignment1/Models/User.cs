using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class User
    {
        // User model with required fields
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
       
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string? Phone { get; set; }

        // Method to check if required fields are empty
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

        // Method to check if password and confirm password are same
        public bool isPasswordConfirmed()
        {
            return Password == ConfirmPassword ? true : false;
        }

        // Method to check if password length is greater than 6
        public bool passwordValidation()
        {
            return Password.Length > 6 ? true : false;
        }

        //method to check if the credentials match
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
