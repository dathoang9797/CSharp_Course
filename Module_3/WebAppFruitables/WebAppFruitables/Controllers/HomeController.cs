using Microsoft.AspNetCore.Mvc;

namespace WebAppFruitables;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    
    public IActionResult Shop() => View();
    public IActionResult Details() => View();
    public IActionResult Contact() => View();
    public IActionResult Testimonial() => View();
    public IActionResult Error404() => View();
}