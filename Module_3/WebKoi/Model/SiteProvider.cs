using WebKoi.Model;
using WebKoi.Repository;

namespace WebKoi.Models;

public class SiteProvider : BaseProvider
{
    public SiteProvider(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    private CustomerRepository customer;
    public CustomerRepository Customer => customer ??= new CustomerRepository(Context);

    private RoleRepository role;
    public RoleRepository Role => role ??= new RoleRepository(Context);

    private ServiceRepository service;
    public ServiceRepository Service => service ??= new ServiceRepository(Context);

    private BusinessRepository business;
    public BusinessRepository Business => business ??= new BusinessRepository(Context);

    private NumberOfOrderRepository numberofOrder;
    public NumberOfOrderRepository NumberofOrder => numberofOrder ??= new NumberOfOrderRepository(Context);
    
    private MemberRepository member;
    public MemberRepository Member => member ??= new MemberRepository(Context);
    
    private ArticleRepository article;
    public ArticleRepository Article => article ??= new ArticleRepository(Context);
    
    private StatusRepository status;
    public StatusRepository Status => status ??= new StatusRepository(Context);
    
    private InvoiceRepository invoice;
    public InvoiceRepository Invoice => invoice ??= new InvoiceRepository(Context);
}