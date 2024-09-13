namespace Module_2.Buoi1.Class;

public class Person
{
    public int A { get; set; }
    public int? B { get; set; }
    public string Name { get; set; } = null!; //Not null
    public string? Color { get; set; } // Nullable
    public decimal Salary { get; set; }
    public DateTime DateOfBird { get; set; }
}