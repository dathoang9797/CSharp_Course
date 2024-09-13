namespace Buoi7;

public class Animal
{
    public string name;
    public int age;

    public Animal(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void Go()
    {
        Console.WriteLine($"{name} with {age} go");
    }
}