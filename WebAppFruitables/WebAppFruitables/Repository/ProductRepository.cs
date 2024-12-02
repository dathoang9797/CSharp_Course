using Microsoft.EntityFrameworkCore;
using WebAppAuthentication.Model;
using WebAppFruitables.Model;

namespace WebAppFruitables.Repository;

public class ProductRepository : BaseRepository
{
    public ProductRepository(FruitableContext context) : base(context)
    {
    }

    public List<Product> GetProducts()
    {
        return Context.Product.Include(p => p.Category).ToList();
    }

    public int Delete(int id)
    {
        var product = Context.Product.Find(id);
        if (product != null)
        {
            Context.Product.Remove(product);
            return Context.SaveChanges();
        }

        return -1;
    }
}