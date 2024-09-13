namespace Buoi7;

public class Dog : Animal
{
    public string color;

    public Dog(string name, int age, string color) : base(name, age)
    {
        this.color = color;
    }

    public void Eat()
    {
        Console.WriteLine($"Dog Eat {color}");
    }
}