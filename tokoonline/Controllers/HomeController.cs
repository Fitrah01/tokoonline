using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var email = HttpContext.Session.GetString("UserEmail");

        if (email == null)
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.Email = email;
        return View();
    }
}