using Microsoft.AspNetCore.Mvc;
using WebAppFruitables;

namespace WebAppFruitable.Controllers;

public class DetailController : BaseController
{
    private const string CartCode = "cart";

    public IActionResult Index()
    {
        var code = Request.Cookies[CartCode];
        if (!string.IsNullOrEmpty(code))
        {
            var cart = Provider.Cart.GetList(code);
            if (cart.Count == 0)
            {
                Response.Cookies.Delete(CartCode);
                return Redirect("/home");
            }

            ViewBag.Carts = cart;
        }
        return View();
    }

    [HttpPost]
    public IActionResult Index(string productName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(productName))
                return Redirect("/home");
            
            var code = Request.Cookies[CartCode];
            if (!string.IsNullOrEmpty(code))
            {
                var cart = Provider.Cart.GetList(code);
                if (cart.Count == 0)
                {
                    Response.Cookies.Delete(CartCode);
                    return Redirect("/home");
                }

                ViewBag.Carts = cart;
            }

            var product = Provider.Product.GetProductByExactName(productName);
            if (product == null)
            {
                TempData["ProductNotFound"] ="Product not found";
                return Redirect("/home");
            }

            return View(product);
        }
        catch (Exception e)
        {
            TempData["ProductNotFound"] ="Product not found";
            return Redirect("/home");
        }
    }
}