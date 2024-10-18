using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class BaseController : Controller
{
    private SiteProvider? _provicer;


    protected SiteProvider Provider =>
        _provicer ??= new SiteProvider(HttpContext.RequestServices.GetRequiredService<IConfiguration>());
}