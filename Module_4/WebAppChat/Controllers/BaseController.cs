using Microsoft.AspNetCore.Mvc;
using WebAppChat.Models;

namespace WebAppChat.Controllers;

public class BaseController : Controller
{
    private SiteProvider? _provicer;


    protected SiteProvider Provider =>
        _provicer ??= new SiteProvider(HttpContext.RequestServices.GetRequiredService<IConfiguration>());
}