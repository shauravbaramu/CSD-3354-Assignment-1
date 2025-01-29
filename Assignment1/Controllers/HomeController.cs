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
        //Signup page with signup form
        public IActionResult Signup(User user)
        {
            if(ModelState.IsValid)
            {
                // Adding user to the list
                Users.Add(user);

                ViewBag.Success = "Registration has been successfully completed.";

                return View("Index", new User());
            }
            

            return View("Index", user);
        }


        [HttpGet]
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //Login page with login form
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
