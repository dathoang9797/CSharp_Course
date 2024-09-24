using Microsoft.AspNetCore.Mvc;

namespace WebAp;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}