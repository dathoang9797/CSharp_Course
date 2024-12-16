using Microsoft.AspNetCore.Mvc;
using WebAppFruitable.Model;

namespace WebAppFruitable.Controllers;

public abstract class BaseController : Controller
{
    private SiteProvider? _provider;
    protected SiteProvider Provider => _provider ??= HttpContext.RequestServices.GetRequiredService<SiteProvider>();
}