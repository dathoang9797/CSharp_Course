using Euro.Models;
using WebAppVNPayment.Models;

namespace WebAppVNPayment.Repository;

public class ProductRepository : BaseRepository
{
    public ProductRepository(StoreContext context) : base(context)
    {
    }

    public List<Product> GetListProduct()
    {
        return Context.Products.ToList();
    }
}