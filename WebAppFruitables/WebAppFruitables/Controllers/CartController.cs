using Microsoft.AspNetCore.Mvc;

namespace WebAppFruitables;

public class CartController : BaseController
{
    public IActionResult Index() => View();
    public IActionResult Checkout() => View();
}