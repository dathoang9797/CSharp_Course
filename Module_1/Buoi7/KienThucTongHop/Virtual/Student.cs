namespace Buoi7;

public class Student : PersonVirtual
{
    public override void Go()
    {
        Console.WriteLine("Student Go");
    }

    public new void Eat()
    {
        Console.WriteLine("Student Eat");
    }
}