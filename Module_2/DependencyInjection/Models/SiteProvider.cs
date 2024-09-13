namespace DependencyInjection.Models;

public class SiteProvider
{
    //Native

    //Fields
    private CategoryRepository category;
    private ProductRepository product;
    private StoreContext context;

    //contructor
    public SiteProvider(StoreContext storeContext)
    {
        Console.WriteLine("Site provider constructor");
        context = storeContext;
    }

    //Properties
    public CategoryRepository Category
    {
        get
        {
            if (category is null)
            {
                category = new CategoryRepository(context);
            }

            return category;
        }
    }

    public ProductRepository Product
    {
        get
        {
            if (product is null)
            {
                product = new ProductRepository(context);
            }

            return product;
        }
    }
}