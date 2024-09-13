using Buoi7;

namespace Module_1.Buoi7;

public class Buoi7
{
    public Buoi7()
    {
//=================OOP===================
        var animal = new Animal("Kak", 15);
        var dog = new Dog("Kak", 15, "Black");

        animal.Go();
        dog.Eat();
        dog.Go();

        Animal animalTwo = new Dog("Kak", 15, "Black");
//=================OOP===================

//=================Inherit===================
// var circleTwo = new Circle(3);
// Console.WriteLine($"Dien tich: {circleTwo.Area()}");
// Console.WriteLine($"Chu vi: {circleTwo.Perimeter()}");
//
// var ellipseTwo = new Ellipse(2, 3);
// Console.WriteLine($"Dien tich: {ellipseTwo.Area()}");
// Console.WriteLine($"Chu vi: {ellipseTwo.Perimeter()}");
//
//
// var rectangle = new Retacngle(2, 3);
// Console.WriteLine($"Dien tich: {rectangle.Area()}");
// Console.WriteLine($"Chu vi: {rectangle.Perimeter()}");
//
// var square = new Square(4);
// Console.WriteLine($"Dien tich : {square.Area()}");
// Console.WriteLine($"Chu vi : {square.Perimeter()}");
//
var triangle = new Triangle(2, 3, 4);
Console.WriteLine($"Dien tich: {triangle.Area()}");
Console.WriteLine($"Chu vi: {triangle.Perimeter()}");

// Shape[] shapes =
// {
//     new Circle(3),
//     new Ellipse(2, 3),
//     new Retacngle(2, 3),
//     new Square(4),
//     new Triangle(2, 3, 4)
// };
//
// double sumArea = 0, sumPerimeter = 0;
// foreach (var shape in shapes)
// {
//     sumArea += shape.Area();
//     sumPerimeter += shape.Perimeter();
//     Console.WriteLine(shape.Area());
// }
//
// Console.WriteLine($"Tong dien tich: {sumArea}, Tong chu vi {sumPerimeter}");

// var shapeTwo = new Shape();
// Console.WriteLine(shapeTwo.Area());
// Console.WriteLine(shapeTwo.Perimeter());
//=================Inherit===================

//=================Virtual===================
// => Virtual (parent) => Override(child)
// => NonVirtual (parent) => New(child)
// var person = new Person();
// person.Go();
// person.Eat();
//
// var student = new Student();
// student.Go();
// student.Eat();
//
// Person p = new Student();
// p.Go(); // Có tính đa xạ (Polymorphism) person vs student (student)
// p.Eat(); //Không có tính đa xạ (Polymorphism) person vs student (person)
//=================Virtual===================

//=================Abstract===================
// Person personOne = new Employee("Lulu");
// var personTwo = new Person("kiki"); //abstract không thể khởi tạo

// personOne.DoSomeThing();
// personTwo.DoSomeThing(); ////abstract không thể khởi tạo
//=================Abstract===================
    }
}