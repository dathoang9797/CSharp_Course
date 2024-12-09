using WebAppFruitable.Model;
using WebAppFruitable.Repository;
using WebAppFruitables.Repository;
using WebAppVNPayment.Repository;

namespace WebAppFruitable.Model;

public class SiteProvider
{
    private readonly FruitableContext context;
    public SiteProvider(FruitableContext context) => this.context = context;

    private CategoryRepository _category = null!;
    private SlideRepository _slide = null!;
    private TestimonialRepository _testimonial = null!;
    private MemberRepository _member = null!;
    private ProductRepository _product = null!;

    public CategoryRepository Category => _category ??= new CategoryRepository(context);
    public SlideRepository Slide => _slide ??= new SlideRepository(context);
    public TestimonialRepository Testimonial => _testimonial ??= new TestimonialRepository(context);
    public MemberRepository Member => _member ??= new MemberRepository(context);
    public ProductRepository Product => _product ??= new ProductRepository(context);
    
    private VnPaymentRepository _vnPayment;
    public VnPaymentRepository VnPayment => _vnPayment ??= new VnPaymentRepository(context);

    private CartRepository _cart;
    public CartRepository Cart => _cart ??= new CartRepository(context);

}