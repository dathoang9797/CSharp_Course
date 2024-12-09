using Microsoft.AspNetCore.Mvc;
using WebAppFruitable.Model;

namespace WebAppFruitables;

public abstract class BaseController : Controller
{
    private SiteProvider? provicer;
    protected SiteProvider Provider => provicer ??= HttpContext.RequestServices.GetRequiredService<SiteProvider>();
}