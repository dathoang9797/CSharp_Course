namespace Buoi7;

public abstract class PersonAbstract // Không thể khởi tạo một instance
{
    string name;

    public PersonAbstract(string name)
    {
        this.name = name;
    }

    // abstract method
    // Không cần cài đặt => chỉ cần khai báo mẫu (prototype)
    // Khi lớp con kế thừa => Bắt buột phải cài đặt phương t
    public abstract void Go();

    public virtual void Eat()
    {
    }

    public virtual void DoSomeThing()
    {
        Console.WriteLine("Hello-1");
    }
}

// var person = new Person();