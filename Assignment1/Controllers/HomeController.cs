using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {

        // List to temporarily store user data 
        private static List<User> Users = new List<User>();


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //Home page with signup form
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (user.isPasswordConfirmed() && user.passwordValidation())
            {
                // Add the user to the list
                Users.Add(user);

                ViewBag.Success = "Registration has been successfully completed.";
            }
            else if (!user.requiredValidation())
            {
                ViewBag.Error = "Error! Some required fields are empty.";
            }
            else if (!user.passwordValidation())
            {
                ViewBag.Error = "Password length must be greater than 6";
            }
            else if (!user.isPasswordConfirmed())
            {
                ViewBag.Error = "Password and Confirm password don't match!";
            }

            return View("Index");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if(user.isCredentialMatch(Users) != null)
            {
                return View("Welcome");
            }
            
            ViewBag.Error = "Invalid email or password. Please try again.";
            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
