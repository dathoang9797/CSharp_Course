using WebApp.Repository;

namespace WebApp.Models;

public class SiteProvider : BaseProvider
{
    public SiteProvider(IConfiguration configuration) : base(configuration)
    {
    }

    private UploadRepository upload;
    public UploadRepository Upload => upload ??= new UploadRepository(Connection);
}