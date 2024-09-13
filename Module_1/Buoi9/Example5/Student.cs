namespace Buoi9;

public class Student
{
    //Chỉ gọi 1 lần duy nhất
    static Student()
    {
        Console.WriteLine("Constructor static");
    }

    public Student()
    {
        Console.WriteLine("Constructor non static");
    }

    public static void DoSomeThing()
    {
        Console.WriteLine("Static Do Some Thing");

    }
}