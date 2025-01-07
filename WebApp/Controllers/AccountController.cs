using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Prosta logika logowania (możesz ją zastąpić czymś bardziej zaawansowanym)
            if (username == "admin" && password == "admin123")
            {
                HttpContext.Session.SetString("User", username); // Zapisujemy użytkownika w sesji
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Nieprawidłowa nazwa użytkownika lub hasło.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User"); // Usuwamy użytkownika z sesji
            return RedirectToAction("Index", "Home");
        }
    }
}
