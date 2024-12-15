using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppFruitable.Model;
using WebAppFruitable.Services;
using WebAppFruitable.VnPayment;
using WebAppFruitables;

namespace WebAppFruitable.Controllers;

public class CartController : BaseController
{
    private const string CartCode = "cart";
    private VnPaymentService? Service { get; set; }
    
    public CartController(
        VnPaymentService service
    )
    {
        Service = service;
    }

    [Authorize]
    public IActionResult Index()
    {
        var code = Request.Cookies[CartCode];
        if (string.IsNullOrEmpty(code))
            return Redirect("/");

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

        var listCart = Provider.Cart.GetList(code);
        return View(listCart);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Add(CartFrom obj)
    {
        var memberId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var code = Request.Cookies[CartCode];
        if (string.IsNullOrEmpty(code))
        {
            code = Helper.RandomString(32);
            Response.Cookies.Append(CartCode, code);
        }

        var cart = new Cart
        {
            MemberId = memberId,
            ProductId = obj.ProductId,
            Quantity = obj.Quantity,
            CartCode = code
        };

        var ret = Provider.Cart.Add(cart);
        return ret > 0
            ? Ok(new { message = "Item deleted successfully." })
            : StatusCode(500, new { message = "Failed to delete the item." });
    }

    [HttpPut]
    public IActionResult Update(CartFrom obj)
    {
        if (User.Identity?.IsAuthenticated == false)
            return Redirect("/auth/login");

        var memberId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var code = Request.Cookies[CartCode];
        if (string.IsNullOrEmpty(code))
        {
            code = Helper.RandomString(32);
            Response.Cookies.Append(CartCode, code);
        }

        var cart = new Cart()
        {
            MemberId = memberId,
            ProductId = obj.ProductId,
            Quantity = obj.Quantity,
            CartCode = code
        };

        var ret = Provider.Cart.Update(cart);
        return Ok(ret);
    }

    [HttpDelete]
    [Route("cart/{cartCode}/{productId}")]
    public IActionResult Delete([FromRoute] string cartCode, [FromRoute] string productId)
    {
        if (User.Identity?.IsAuthenticated == false)
            return Redirect("/auth/login");

        if (string.IsNullOrWhiteSpace(cartCode))
            return Redirect("/cart/error");

        var ret = Provider.Cart.Delete(cartCode, Convert.ToInt16(productId));
        if (ret > 0)
        {
            var cart = Provider.Cart.GetList(cartCode);
            if (cart.Count == 0)
            {
                Response.Cookies.Delete(CartCode);
                return Redirect("/home");
            }
        }

        return ret > 0
            ? Ok(new { message = "Item deleted successfully." })
            : StatusCode(500, new { message = "Failed to delete the item." });
    }

    public IActionResult Checkout()
    {
        var code = Request.Cookies[CartCode];
        if (string.IsNullOrEmpty(code))
            return Redirect("/");

        var listCart = Provider.Cart.GetList(code);
        return View(listCart);
    }

    [HttpPost]
    [Route("cart/checkout")]
    public IActionResult Checkout(Invoice obj)
    {
        var code = Request.Cookies[CartCode];
        if (string.IsNullOrEmpty(code))
            return Redirect("/");

        var listCart = Provider.Cart.GetList(code);
        var amount = listCart.Sum(item => item.Product != null ? item.Product.Price * item.Quantity : 0);
        obj.Amount = (int)(amount * 100);

        var random = new Random();
        obj.InvoiceId = random.NextInt64(99999, long.MaxValue);
        var url = Service?.ToUrlPayment(obj);
        if (string.IsNullOrWhiteSpace(url))
        {
            return Checkout();
        }

        return Redirect(url);
    }

    public IActionResult BackVnPayment(VnPaymentResponse? obj)
    {
        if (obj == null)
            return Checkout();

        Response.Cookies.Delete(CartCode);
        var ret = Provider.VnPayment.Add(obj);
        return Redirect(ret > 0 ? "/home" : "/cart/failed");
    }
}