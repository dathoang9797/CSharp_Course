namespace Buoi8.Static;

public class RandomInt
{
    Random random = new Random();
    public RandomInt()
    {
        Console.WriteLine("Sinh so ngau nhien");
        Console.WriteLine(random.Next());
        Console.WriteLine("*******************");
    }
}

public class DemoStatic
{
    public static int a = 0;
    public int b = 0;
    static RandomInt random = new RandomInt();

    public DemoStatic()
    {
        a++;
        b++;
        Console.WriteLine($"a: {a}, b: {b}");
    }
}