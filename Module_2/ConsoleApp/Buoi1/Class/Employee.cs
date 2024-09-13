namespace Module_2.Buoi1.Class;

public class Employee
{
    private int id;
    private string name;
    private int age;
    private DateTime dateOfBirth;

    public Employee(int id, string name, int age, DateTime dateOfBirth)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.dateOfBirth = dateOfBirth;
    }


    //Method
    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    //Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Id { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
}