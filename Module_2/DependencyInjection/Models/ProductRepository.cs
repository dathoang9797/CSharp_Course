namespace DependencyInjection.Models;

public class ProductRepository
{
    private StoreContext _storeContext;

    public ProductRepository(StoreContext storeContext)
    {
        Console.WriteLine("Product Contructor");
        _storeContext = storeContext;
    }

    public void DoThat()
    {
        Console.WriteLine("Product DoThat");
    }
}