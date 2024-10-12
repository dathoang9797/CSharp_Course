using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebKoi;

public class CartController : BaseController
{
    public CartController(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    [Authorize]
    public IActionResult Invoices()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(id))
            return Redirect($"/auth/Login");

        return View(Provider.Invoice.GetInvoiceByMember(id));
    }

    [Authorize]
    public IActionResult Invoice(int id)
    {
        return View(Provider.Invoice.GetInvoice(id));
    }
}