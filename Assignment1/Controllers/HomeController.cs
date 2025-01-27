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
<<<<<<< HEAD
            if (user.Password.Length < 6)
            {
                ViewBag.Error = "Password must contain at least 6 characters.";
                return View("Index");
            }

            if (user.isPasswordConfirmed())
=======
            if (ModelState.IsValid)
>>>>>>> ae0513bb8ae8020d87b5c88680193efae163263c
            {
                // Add the user to the list
                Users.Add(user);

                ViewBag.Success = "Registration has been successfully completed.";
            }
            else
            {
                ViewBag.Error = "Error! There are some validation errors.";
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
            User? userData = null;
            foreach (var user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    userData = user;
                }

            }
            if (userData != null)
            {
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewBag.Error = "Invalid email or password. Please try again.";
                return View();
            }
        }

        public IActionResult Welcome()
        {
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
