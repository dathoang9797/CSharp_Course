using Microsoft.AspNetCore.Mvc;

namespace WebAppFruitable.Controllers;

public class InvoiceController : BaseController
{
    [HttpGet]
    [Route("invoice/{memberId}")]
    public IActionResult Index([FromRoute] string memberId)
    {
        if (string.IsNullOrWhiteSpace(memberId))
            return Redirect("/home");
        
        var invoices = Provider.Invoice.GetInvoice(memberId);
        return View(invoices);
    }
}