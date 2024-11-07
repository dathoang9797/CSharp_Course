using DAL;
using Microsoft.Extensions.Caching.Memory;

namespace WebAppClassLib.Models;

public class ManufactureService : BaseService
{
    //Database Cache


    public ManufactureService(IMemoryCache cache, SiteProvider provider) : base(cache, provider)
    {
    }

    //Memory Cache
    public IEnumerable<Manufacturer> GetManufacturers()
    {
        const string cacheKey = "manufacturer";
        var list = Cache.Get<IEnumerable<Manufacturer>>(cacheKey);
        if (list is null)
        {
            Console.WriteLine("Read Database");
            list = Provider.Manufacture.GetManufactures();
            Cache.Set(cacheKey, list, new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });
        }
        else
        {
            Console.WriteLine("Read Cache");
        }

        return list;
    }
}