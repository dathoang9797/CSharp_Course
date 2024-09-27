using Microsoft.AspNetCore.Mvc;
using WebAppAuthentication.Model;
using WebApplication1.Models;

namespace WebAppFruitables;

public abstract class BaseController : Controller
{
    private SiteProvider? provicer;

    //Cach 1 khong can AddScoped vo file program
    // protected SiteProvider Provider =>
    //     provicer ??= new SiteProvider(HttpContext.RequestServices.GetRequiredService<FruitableContext>());

    protected SiteProvider Provider => provicer ??= HttpContext.RequestServices.GetRequiredService<SiteProvider>();
}