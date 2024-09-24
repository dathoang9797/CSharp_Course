using Microsoft.AspNetCore.Mvc;

namespace WebAppFruitables;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    
    public IActionResult Shop() => View();
}