using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

public class BaseController : ControllerBase
{
    SiteProvider? provider { get; set; }

    protected SiteProvider Provider =>
        provider ??= new SiteProvider(HttpContext.RequestServices.GetRequiredService<IConfiguration>());
}