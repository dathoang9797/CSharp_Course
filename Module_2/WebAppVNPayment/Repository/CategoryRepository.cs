using Euro.Models;
using WebAppVNPayment.Models;

namespace WebAppVNPayment.Repository;

public class CategoryRepository : BaseRepository
{
    public CategoryRepository(StoreContext context) : base(context)
    {
    }

    public List<Category> GetListCategories()
    {
        return Context.Categories.ToList();
    }
}