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
}