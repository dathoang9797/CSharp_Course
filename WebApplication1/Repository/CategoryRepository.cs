using Microsoft.EntityFrameworkCore;
using WebAppAuthentication.Model;
using WebAppFruitables.Model;

namespace WebAppFruitables.Repository;

public class CategoryRepository : BaseRepository
{
    public CategoryRepository(FruitableContext context) : base(context)
    {
    }

    public List<Category> GetCategories()
    {
        return Context.Categories.ToList();
    }

    public List<CategoryCount> GetCategoryCounts()
    {
        var categories = Context.Categories.Include(p => p.Products);
        return categories.Select(p => new CategoryCount()
        {
            CategoryId = p.CategoryId,
            CategoryName = p.CategoryName,
            Count = p.Products!.Count()
        }).ToList();
    }
}