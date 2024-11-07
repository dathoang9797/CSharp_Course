using DAL;
using WebAppClassLib.Models;

namespace WebAppClassLib;

public class WebProvider : WebBaseProvider
{
    public WebProvider(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    private ManufactureService manufacturer;
    public ManufactureService Manufacturer => manufacturer ??= new ManufactureService(Cache, Provider);
}