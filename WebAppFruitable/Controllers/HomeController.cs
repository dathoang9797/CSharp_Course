using Microsoft.AspNetCore.Mvc;
using WebAppFruitables;

namespace WebAppFruitable.Controllers;

public class HomeController : BaseController
{
    private const string CartCode = "cart";
    public IActionResult Index()
    {
        ViewBag.Categories = Provider.Category.GetCategories();
        ViewBag.Products = Provider.Product.GetProducts();

        var code = Request.Cookies[CartCode];
        if (!string.IsNullOrEmpty(code))
            ViewBag.Carts = Provider.Cart.GetList(code);

        return View();
    }

    public IActionResult Details() => View();
    public IActionResult Contact() => View();
    public IActionResult Testimonial() => View();
    public IActionResult Error404() => View();
}