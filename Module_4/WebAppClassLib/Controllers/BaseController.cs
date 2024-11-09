using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebAppClassLib.Controllers;

public abstract class BaseController : Controller
{
    private IConfiguration Configuration { get; set; }

    public BaseController(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private WebProvider? _provider;
    protected WebProvider Provider => _provider ??= HttpContext.RequestServices.GetRequiredService<WebProvider>();

    private SiteProvider? _siteProvider;

    protected SiteProvider SiteProvider =>
        _siteProvider ??= HttpContext.RequestServices.GetRequiredService<SiteProvider>();

    private SiteProvider? _siteProviderTest;

    protected SiteProvider SiteProviderTest => _siteProviderTest ??= new SiteProvider(Configuration);
}