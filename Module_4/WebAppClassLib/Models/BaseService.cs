using DAL;
using Microsoft.Extensions.Caching.Memory;

namespace WebAppClassLib.Models;

public abstract class BaseService
{
    protected IMemoryCache Cache { get; set; }
    protected SiteProvider Provider { get; set; }

    protected BaseService(IMemoryCache cache, SiteProvider provider)
    {
        Cache = cache;
        Provider = provider;
    }
}