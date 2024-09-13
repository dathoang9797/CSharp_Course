using Buoi7;
namespace Module_1.Buoi9;

public class Buoi9
{
    public Buoi9()
    {
        var circleTwo = new Circle(3);
        Console.WriteLine($"Dien tich: {circleTwo.Area()}");
        Console.WriteLine($"Chu vi: {circleTwo.Perimeter()}");

        var ellipseTwo = new Ellipse(2, 3);
        Console.WriteLine($"Dien tich: {ellipseTwo.Area()}");
        Console.WriteLine($"Chu vi: {ellipseTwo.Perimeter()}");


        var rectangle = new Retacngle(2, 3);
        Console.WriteLine($"Dien tich: {rectangle.Area()}");
        Console.WriteLine($"Chu vi: {rectangle.Perimeter()}");

        var square = new Square(4);
        Console.WriteLine($"Dien tich : {square.Area()}");
        Console.WriteLine($"Chu vi : {square.Perimeter()}");

        var triangle = new Triangle(2, 3, 4);
        Console.WriteLine($"Dien tich: {triangle.Area()}");
        Console.WriteLine($"Chu vi: {triangle.Perimeter()}");

//class, abstract class => đơn dế thừa
//interface => đa kế thừa
//interface không thể kế thừa class
// IAnimal animal = new Cat();

// animal.Eat();
// animal.Go();
//
// var cat = new Cat();
// cat.Go();
// cat.Eat();

// Student.DoSomeThing();
//class static
// var student = new Student();
// var student2 = new Student();

//constructor static

// string[] wordArray = { "wheels", "on", "the", "bus" };
// var stringChooser = new RandomStringChooser(wordArray);
// for (var i = 0; i < 6; i++)
// {
//     Console.Write($"{stringChooser.GetNext()} ");
// }
//
// Console.WriteLine();
// var letterChooser = new RandomLetterChooser("cat");
// for (var i = 0; i < 4; i++)
// {
//     Console.Write($"{letterChooser.GetNext()} ");
// }

// var animal = new Animal();
// animal.Go();

//Animal => class
//Animal.DoSomeThing();
// Animal.DoSomeThing();

// var parent = new Parent();
// var child = new Child();
// Parent.DoSomeThing();
// Child.DoSomeThing();
    }
}