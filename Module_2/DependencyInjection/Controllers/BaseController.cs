using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

public abstract class BaseController : Controller
{
    // protected static CategoryRepository _categoryRepository = new CategoryRepository();
    // protected SiteProvider provider;
    // Properties(hay của properties)=> Auto properties đã thay thế properties
    // Phải xử lý StoreContext(tệ điểm yếu của constructor)
    // public BaseController(StoreContext context)
    // {
    //     provider = new SiteProvider(context);
    // }
    
    private SiteProvider _provider = null!;
    protected SiteProvider Provider
    {
        get
        {
            if (_provider is null)
            {
                _provider = HttpContext.RequestServices.GetRequiredService<SiteProvider>();
            }

            return _provider;
        }
    }

   
}