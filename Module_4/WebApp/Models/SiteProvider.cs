using WebApp.Repository;

namespace WebApp.Models;

public class SiteProvider : BaseProvider
{
    public SiteProvider(IConfiguration configuration) : base(configuration)
    {
    }

    private UploadRepository upload;
    public UploadRepository Upload => upload ??= new UploadRepository(Connection, Configuration);

    private UploadBase64Repository uploadbase64;

    public UploadBase64Repository Uploadbase64 =>
        uploadbase64 ??= new UploadBase64Repository(Connection, Configuration);

    private CategoryRepository _category;
    public CategoryRepository Category => _category ??= new CategoryRepository(Configuration);

    private ProductRepository _product;
    public ProductRepository Product => _product ??= new ProductRepository(Configuration);

    private MemberRepository _member;
    public MemberRepository Member => _member ??= new MemberRepository(Connection, Configuration);
    
    private RoleRepository _role;
    public RoleRepository Role => _role ??= new RoleRepository(Connection, Configuration);
    
    private MemberInRoleRepository _memberInRole;
    public MemberInRoleRepository MemberInRole => _memberInRole ??= new MemberInRoleRepository(Connection, Configuration);
    
    private AccessRepository _access;
    public AccessRepository Access => _access ??= new AccessRepository(Connection, Configuration);
    
    private AccessRoleRepository _accessRole;
    public AccessRoleRepository AccessRole => _accessRole ??= new AccessRoleRepository(Connection, Configuration);
}