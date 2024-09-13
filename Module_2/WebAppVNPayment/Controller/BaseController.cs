using WebAppVNPayment.Models;

namespace WebAppVNPayment.Controller;

public abstract class BaseController : Microsoft.AspNetCore.Mvc.Controller
{
    private SiteProvider? provider;

    protected SiteProvider Provider => provider ??= HttpContext.RequestServices.GetRequiredService<SiteProvider>();
}