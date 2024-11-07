using Microsoft.AspNetCore.Mvc;

namespace WebAppClassLib.Controllers;

public abstract class BaseController : Controller
{
    protected WebProvider provider;
    protected WebProvider Provider => provider ??= HttpContext.RequestServices.GetRequiredService<WebProvider>();
}