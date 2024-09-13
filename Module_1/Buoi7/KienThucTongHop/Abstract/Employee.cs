namespace Buoi7;

public class Employee : PersonAbstract

{
    public Employee(string name) : base(name)
    {
    }
    
    public override void Go()
    {
        Console.WriteLine($"Employee go");
    }
    
    public override void DoSomeThing()
    {
        Console.WriteLine("Hello-2");
    }
}