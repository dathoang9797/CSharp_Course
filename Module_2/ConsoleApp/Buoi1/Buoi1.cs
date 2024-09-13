using Module_2.Buoi1.Class;

namespace Module_2.Buoi1;

public class Buoi1
{
    public Buoi1()
    {
        // var e1 = new Employee(137, "thien", 20, new DateTime(2000, 3, 15));
        //Cach 1
        // Console.WriteLine(e1.GetName());

        //Cach2
        // Console.WriteLine(e1.Name);

        // e1.Name = "Dat";
        // Console.WriteLine(e1.Name);

        // e1.Id = 3;
        // e1.Age = 27;
        // e1.DateOfBirth = new DateTime(1990, 5, 21);
        // Console.WriteLine($"Id: {e1.Id}, Age:{e1.Age}, Date of birth:{e1.DateOfBirth}");

        var person = new Person()
        {
            Name = "Dat",
            Color = "Black",
            Salary = 7.3m,
            DateOfBird = new DateTime(2000, 3, 31)
        };

        Console.WriteLine(person.A);
        Console.WriteLine(person.B);
    }
}