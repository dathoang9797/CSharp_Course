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

    [Authorize]
    public IActionResult Index()
    {
        var code = Request.Cookies[CartCode];
        if (string.IsNullOrEmpty(code))
            return Redirect("/");

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

        var cart = new Cart()
        {
            MemberId = memberId,
            ProductId = obj.ProductId,
            Quantity = obj.Quantity,
            CartCode = code
        };

        var ret = Provider.Cart.Add(cart);
        return Redirect(ret > 0 ? "/cart" : "/cart/error");
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
        return ret > 0
            ? Ok(new { message = "Item deleted successfully." })
            : StatusCode(500, new { message = "Failed to delete the item." });
    }

    public IActionResult Checkout() => View();

    [HttpPost]
    public IActionResult Checkout(Invoice obj)
    {
        var random = new Random();
        obj.InvoiceId = random.NextInt64(99999, long.MaxValue);
        // return Json(obj);
        var url = Service?.ToUrlPayment(obj);
        if (string.IsNullOrWhiteSpace(url))
            return View(obj);

        return Redirect(url);
    }

    public IActionResult BackVnPayment(VnPaymentResponse obj)
    {
        var ret = Provider.VnPayment.Add(obj);
        return Redirect(ret > 0 ? "/cart/success" : "/cart/failed");
    }
}