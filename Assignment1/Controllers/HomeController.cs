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

        //Home page with signup form
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Signup(User user, string confirmPassword)
        {
            if (user.Password == confirmPassword)
            {
                // Add the user to the list
                Users.Add(user);

                ViewBag.Message = "Registration has been successfully completed";
            }
            else
            {
                ViewBag.Message = "Password and confirmation do not match";
            }
            return View("Index");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]


        public IActionResult Login(string email, string password)
        {
            // Check if the user exists in the list
            var user = Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                TempData["UserName"] = user.FirstName; // Pass user's name to the welcome page
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewBag.Message = "Invalid email or password. Please try again.";
                return View();
            }
        }

        public IActionResult Welcome()
        {
            ViewBag.UserName = TempData["UserName"];
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
