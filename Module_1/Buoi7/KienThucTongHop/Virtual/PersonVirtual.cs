namespace Buoi7;

public class PersonVirtual
{
    public virtual void Go()
    {
        Console.WriteLine($"Virtual Persion Go");
    }

    public void Eat()
    {
        Console.WriteLine($"NonVirtual Persion Eat");
    }
}