using WebAppFruitable.Model;
using WebAppFruitable.Repository;
using WebAppFruitable.Repository;
using WebAppVNPayment.Repository;

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

}