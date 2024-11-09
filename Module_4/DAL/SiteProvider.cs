using Microsoft.Extensions.Configuration;

namespace DAL;

public class SiteProvider : BaseProvider
{
    public SiteProvider(IConfiguration configuration) : base(configuration)
    {
    }

    private ManufactureRepository manufacture;
    public ManufactureRepository Manufacture => manufacture ??= new ManufactureRepository(Connection);
}