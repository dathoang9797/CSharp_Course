using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public abstract class BaseController : Controller
{
    private SiteProvider provider;
    protected SiteProvider Provider
    {
        get
        {
            if (provider is null)
            {
                provider = HttpContext.RequestServices.GetRequiredService<SiteProvider>();
            }

            return provider;
        }
    }
}