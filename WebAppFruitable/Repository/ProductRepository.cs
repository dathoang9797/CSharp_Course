using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;
using WebAppFruitable.Repository;

namespace WebAppFruitable.Repository;

public class ProductRepository : BaseRepository
{
    public ProductRepository(FruitableContext context) : base(context)
    {
    }

    public List<Product> GetProducts()
    {
        return Context.Product.Include(p => p.Category).ToList();
    }

    public Product? GetProduct(int id)
    {
        return Context.Product.FirstOrDefault(p => p.ProductId == id);
    }

    public int Add(Product? product)
    {
        if (product != null)
        {
            Context.Product.Add(product);
            return Context.SaveChanges();
        }

        return -1;
    }

    public int Update(Product? product)
    {
        if (product != null)
        {
            Context.Product.Update(product);
            return Context.SaveChanges();
        }

        return -1;
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

    public Product? GetProductByExactName(string name)
    {
        return Context.Product
            .Include(p => p.Category)
            .FirstOrDefault(p => p.ProductName.ToLower() == name.ToLower());
    }
}