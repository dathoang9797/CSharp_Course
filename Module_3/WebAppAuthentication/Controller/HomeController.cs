using Microsoft.AspNetCore.Mvc;

namespace WebAppAuthentication;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}