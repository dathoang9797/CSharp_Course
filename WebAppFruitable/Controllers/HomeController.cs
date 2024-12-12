using Microsoft.AspNetCore.Mvc;
using WebAppFruitables;

namespace WebAppFruitable.Controllers;

public class HomeController : BaseController
{
    public IActionResult Index()
    {
        ViewBag.Categories = Provider.Category.GetCategories();
        ViewBag.Products = Provider.Product.GetProducts();
        return View();
    }

    public IActionResult Details() => View();
    public IActionResult Contact() => View();
    public IActionResult Testimonial() => View();
    public IActionResult Error404() => View();
}