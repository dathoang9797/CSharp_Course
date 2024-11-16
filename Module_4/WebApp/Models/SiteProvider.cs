using WebApp.Repository;

namespace WebApp.Models;

public class SiteProvider : BaseProvider
{
    public SiteProvider(IConfiguration configuration) : base(configuration)
    {
    }

    private UploadRepository upload;
    public UploadRepository Upload => upload ??= new UploadRepository(Connection);
    
    private UploadBase64Repository uploadbase64;
    public UploadBase64Repository Uploadbase64 => uploadbase64 ??= new UploadBase64Repository(Connection);

    private CategoryRepository _category;
    public CategoryRepository Category => _category ??= new CategoryRepository(Configuration);
}