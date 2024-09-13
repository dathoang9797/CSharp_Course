using Microsoft.AspNetCore.Mvc;

namespace WebAppStore;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}