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

        public bool isPasswordConfirmed()
        {
            bool passwordConfirmed = Password == ConfirmPassword ? true : false;

            return passwordConfirmed;
        }

    }
}
