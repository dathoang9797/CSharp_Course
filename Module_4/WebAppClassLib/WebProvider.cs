using DAL;
using WebAppClassLib.Models;

namespace WebAppClassLib;

public class WebProvider : WebBaseProvider
{
    public WebProvider(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    private ManufactureService _manufacturer;
    public ManufactureService Manufacturer => _manufacturer ??= new ManufactureService(Cache, Provider);
}