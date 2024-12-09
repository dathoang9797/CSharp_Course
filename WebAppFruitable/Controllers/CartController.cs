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
    
    public IActionResult Index()
    {
        var code = Request.Cookies[CartCode];
        if (string.IsNullOrEmpty(code))
            return Redirect("/");
        
        return View(Provider.Cart.GetList(code));
    }
    
    public IActionResult Add(Cart obj)
    {
        var code = Request.Cookies[CartCode];
        if (string.IsNullOrEmpty(code))
        {
            code = Helper.RandomString(32);
            Response.Cookies.Append(CartCode, code);
        }

        obj.CartCode = code;
        var ret = Provider.Cart.Add(obj);
        return Redirect(ret > 0 ? "/cart" : "/cart/error");
    }
    
    public IActionResult Checkout() => View();
    
    [HttpPost]
    public IActionResult Checkout(Invoice obj)
    {
        var random = new Random();
        obj.InvoiceId = random.NextInt64(99999, long.MaxValue);
        // return Json(obj);
        var url = Service.ToUrlPayment(obj);
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