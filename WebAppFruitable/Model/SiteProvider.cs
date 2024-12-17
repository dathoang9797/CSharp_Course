using WebAppFruitable.Repository;

namespace WebAppFruitable.Model;

public class SiteProvider
{
    private readonly FruitableContext context;
    public SiteProvider(FruitableContext context) => this.context = context;

    private CategoryRepository _category = null!;
    public CategoryRepository Category => _category ??= new CategoryRepository(context);
  
    private MemberRepository _member = null!;
    public MemberRepository Member => _member ??= new MemberRepository(context);
   
    private ProductRepository _product = null!;
    public ProductRepository Product => _product ??= new ProductRepository(context);
    
    private VnPaymentRepository _vnPayment;
    public VnPaymentRepository VnPayment => _vnPayment ??= new VnPaymentRepository(context);

    private CartRepository _cart;
    public CartRepository Cart => _cart ??= new CartRepository(context);
    
    private InvoiceRepository _invoice;
    public InvoiceRepository Invoice => _invoice ??= new InvoiceRepository(context);

    private RoleRepository _role;
    public RoleRepository Role => _role ??= new RoleRepository(context);

    private MemberInRoleRepository _memberInRole;
    public MemberInRoleRepository MemberInRole => _memberInRole ??= new MemberInRoleRepository(context);
}