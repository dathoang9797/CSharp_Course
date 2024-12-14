using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;
using WebAppFruitable.Repository;

namespace WebAppFruitable.Repository;

public class CartRepository : BaseRepository
{
    public CartRepository(FruitableContext context) : base(context)
    {
    }

    public List<Cart> GetList(string code)
    {
        return Context.Cart
            .Include(p => p.Product)
            .Include(p => p.Member)
            .Where(p => p.CartCode == code).ToList();
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
    
    public int Update(Cart obj)
    {
        var cartUpdate = Context.Cart.SingleOrDefault(p => p.CartCode == obj.CartCode && p.ProductId == obj.ProductId);
        if (cartUpdate != null)
        {
            cartUpdate.Quantity = obj.Quantity;
            Context.Cart.Update(cartUpdate);
        }

        return Context.SaveChanges();
    }

    public int Delete(string cartCode, int productId)
    {
        var cartItem = Context.Cart.SingleOrDefault(p => p.CartCode == cartCode && p.ProductId == productId);
        if (cartItem != null)
        {
            Context.Cart.Remove(cartItem);
            return Context.SaveChanges();
        }

        return 0;
    }
}