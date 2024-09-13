using WebAppVNPayment.Repository;

namespace WebAppVNPayment.Models;

public class SiteProvider
{
    private readonly StoreContext context;
    private CategoryRepository category;
    private VnPaymentRepository vnPayment;
    private ProductRepository products;
    private CartRepository cart;

    //contructor
    public SiteProvider(StoreContext Context)
    {
        context = Context;
    }

    //Properties
    public CategoryRepository Category => category ??= new CategoryRepository(context);
    public VnPaymentRepository VnPayment => vnPayment ??= new VnPaymentRepository(context);
    public ProductRepository Products => products ??= new ProductRepository(context);
    public CartRepository Cart => cart ??= new CartRepository(context);
}