namespace Buoi9;

public class Child : Parent
{
    public Child()
    {
        Console.WriteLine("Constructor child");
    }

    public static new void DoSomeThing()
    {
    }

    //khi dùng static lớp cha không dùng virtual hoặc abstact
    //lớp con không thể overider
    public void DoThat()
    {
        DoSomeThing();
    }
}