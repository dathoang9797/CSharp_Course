using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppChat.Models;

namespace WebAppChat.Controllers;

public class BaseController : Controller
{
    private SiteProvider? _provicer;


    protected SiteProvider Provider =>
        _provicer ??= new SiteProvider(HttpContext.RequestServices.GetRequiredService<IConfiguration>());
}