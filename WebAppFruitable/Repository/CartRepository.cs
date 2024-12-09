
using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;
using WebAppFruitables.Repository;

namespace WebAppFruitable.Repository;

public class CartRepository : BaseRepository
{
    public CartRepository(FruitableContext context) : base(context)
    {
    }

    public List<Cart> GetList(string code)
    {
        return Context.Cart.Include(p => p.Product).Where(p => p.CartCode == code).ToList();
    }

    public int Add(Cart obj)
    {
        var cartUpdate = Context.Cart.SingleOrDefault(p => p.CartCode == obj.CartCode && p.ProductId == obj.ProductId);
        if (cartUpdate != null)
        {
            cartUpdate.Quantity += obj.Quantity;
            Context.Cart.Update(cartUpdate);
        }
        else
        {
            Context.Cart.Add(obj);
        }

        return Context.SaveChanges();
    }
}