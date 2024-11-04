using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebKoi.Models;
namespace WebKoi;

public abstract class BaseController : Controller
{
    private SiteProvider? _provicer;
    private IHttpContextAccessor _accessor;

    public BaseController(IHttpContextAccessor accessor) => _accessor = accessor;
    
    protected SiteProvider Provider => _provicer ??= new SiteProvider(_accessor);
}