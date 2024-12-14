using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;

namespace WebAppFruitable.Repository;

public class CategoryRepository : BaseRepository
{
    public CategoryRepository(FruitableContext context) : base(context)
    {
    }

    public List<Category> GetCategories()
    {
        return Context.Categories.ToList();
    }

    public Category? GetCategory(int id)
    {
        return Context.Categories
            .Include(p => p.Products)
            .FirstOrDefault(p => p.CategoryId == id);
    }

    public int Add(Category? category)
    {
        if (category != null)
        {
            Context.Categories.Add(category);
            return Context.SaveChanges();
        }

        return -1;
    }
    
    public int Update(Category? category)
    {
        if (category != null)
        {
            Context.Categories.Update(category);
            return Context.SaveChanges();
        }

        return -1;
    }
    
    public int Delete(byte id)
    {
        var category = Context.Categories.Find(id);
        if (category != null)
        {
            Context.Categories.Remove(category);
            return Context.SaveChanges();
        }

        return -1;
    }
}