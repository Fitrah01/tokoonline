using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        if (email == "admin@gmail.com" && password == "12345")
        {
            HttpContext.Session.SetString("UserEmail", email);
            HttpContext.Session.SetString("IsLogin", "true");

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Login gagal";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}