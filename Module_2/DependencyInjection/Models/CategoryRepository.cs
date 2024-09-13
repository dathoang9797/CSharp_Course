namespace DependencyInjection.Models;

public class CategoryRepository
{
    private StoreContext _storeContext;

    public CategoryRepository(StoreContext storeContext)
    {
        Console.WriteLine("Category Contructor");  
        _storeContext = storeContext;
    }
    
    public int Add()
    {
        Console.WriteLine("Category Add");
        return 0;
    }
    
    public void DoSomeThing()
    {
        Console.WriteLine("Category DoSomeThing");
    }
}