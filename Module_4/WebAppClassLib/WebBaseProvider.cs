using DAL;
using Microsoft.Extensions.Caching.Memory;

namespace WebAppClassLib;

public abstract class WebBaseProvider
{
    private SiteProvider? provicer;
    private IMemoryCache? cache;

    private IHttpContextAccessor Accessor;

    public WebBaseProvider(IHttpContextAccessor accessor)
    {
        Accessor = accessor;
    }

    protected IMemoryCache? Cache => cache ??= Accessor.HttpContext?.RequestServices.GetRequiredService<IMemoryCache>();
    protected SiteProvider? Provider => provicer ??= Accessor.HttpContext?.RequestServices.GetRequiredService<SiteProvider>();

}