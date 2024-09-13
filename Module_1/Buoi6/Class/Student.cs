public class Student
{
    //field vs parameters vs local variable
    private string Name { get; set; }
    private int Age { get; set; }
    public string Color { get; set; }

    public Student(string name, int age, string color)
    {
        Name = name;
        Age = age;
        Color = color;
    }

    public void Go(int km)
    {
        int distance;
        Console.WriteLine($"{Name}-{Age} run {km}");
    }

    public string GetName()
    {
        return "xin chao";
    }

    internal void Eat()
    {
        Console.WriteLine("Eating");
    }

    protected void DoSomeThing()
    {
        Console.WriteLine("Eating");
    }

    private void DoThat()
    {
        Console.WriteLine("Eating");
    }

    //private => default
    //protected
    //internal
    //public
}