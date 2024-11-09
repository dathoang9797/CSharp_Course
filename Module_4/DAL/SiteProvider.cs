using Microsoft.Extensions.Configuration;

namespace DAL;

public class SiteProvider : BaseProvider
{
    public SiteProvider(IConfiguration configuration) : base(configuration)
    {
    }

    private ManufactureRepository _manufacture;
    public ManufactureRepository Manufacture => _manufacture ??= new ManufactureRepository(Connection);

    private CategoryRepository _category;
    public CategoryRepository Category => _category ??= new CategoryRepository(Connection);
}