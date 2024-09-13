namespace Module_2;

public class CategoryRepository
{
    public CategoryRepository()
    {
        Console.WriteLine("Category Constructor");
    }

    public void DoSomeThing() => Console.WriteLine("Category DoSomeThing");

    public void DoThat() => Console.WriteLine("Category DoThat");
}

public class SiteProvider
{
    private CategoryRepository category = null!;

    // public CategoryRepository Category
    // {
    //     get
    //     {
            // if (category is null)
            // {
            //     category = new CategoryRepository();
            // }
            //
            // return category;
            
            //Không dùng được toán tử 3 ngôi
            // return category == null ? new CategoryRepository() : category;

    //         return category ??= new CategoryRepository();
    //     }
    // }
    
    public CategoryRepository Category => category ??= new CategoryRepository();
}