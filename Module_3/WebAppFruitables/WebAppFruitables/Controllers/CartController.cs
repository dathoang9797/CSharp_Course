using Microsoft.AspNetCore.Mvc;

namespace WebAppFruitables;

public class CartController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Checkout() => View();
}