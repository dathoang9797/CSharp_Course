namespace Buoi9;

public class Animal
{
    private string name;
    private static int count;

    public static void DoSomeThing()
    {
        // count = 7;
        //name = "Thien

        // var animal = new Animal();
        // animal.name = "Thanh";
        // animal.Go();
        Console.WriteLine("Static Do something");
    }

    public void Go()
    {
        DoSomeThing();
        name = "thien";
        count = 7;
        Console.WriteLine("Non Static go");
    }
}