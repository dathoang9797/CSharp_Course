namespace Module_1.Buoi6;

public class Buoi6
{
    public Buoi6()
    {
// var s1 = new Student("Dat", 27, "Red");
// var s2 = new Student();
// s1.Go(10);
// s2.Go(7);
// Console.WriteLine(s2.GetName());
// s1.Eat();
// Console.WriteLine(s1.Name);
// s1.DoSomeThing();
// s1.DoThat();
// s1.Go(10);

// var square = new Square(10);
// var rectangle = new Rectangle(10, 20);
// var triangle = new Triangle(3, 4, 5);
// var ellipse = new Ellipse(3, 7);
// var circle = new Circle(10);
//
// Console.WriteLine($"Chu vi hinh vuong: {square.Perimeter():0.00}");
// Console.WriteLine($"Dien tich hinh vuong: {square.Area():0.00}");
// Console.WriteLine();
//
// Console.WriteLine($"Chu vi hinh chu nhat: {rectangle.Perimeter():0.00}");
// Console.WriteLine($"Dien tich hinh chu nhat: {rectangle.Area():0.00}");
// Console.WriteLine();
//
// Console.WriteLine($"Chu vi hinh bau duc: {ellipse.Perimeter():0.00}");
// Console.WriteLine($"Dien tich hinh bau duc: {ellipse.Area():0.00}");
// Console.WriteLine();
//
// Console.WriteLine($"Chu vi hinh tron: {circle.Perimeter():0.00}");
// Console.WriteLine($"Dien tich hinh tron: {circle.Area():0.00}");
// Console.WriteLine();
//
// Console.WriteLine($"Chu vi tam giac: {triangle.Perimeter():0.00}");
// Console.WriteLine($"Dien tich tam giac: {triangle.Area():0.00}");

// double[] arr = { 3, 7, 8, 16, 52, 41, 19 };
// var minMaxScale = new MinMaxScale();
// var brr = minMaxScale.FitTransFrom(arr);
// var crr = minMaxScale.Inverse(brr);
//
// Console.WriteLine(string.Join(", ", brr));
// Console.WriteLine(string.Join(", ", crr));


        double[] arr = { -7, 6, -17, 3, 25, -26, 19 };
        var minAbsMaxScale = new MaxAbsScaler();
        var brr = minAbsMaxScale.FitTransFrom(arr);
        var crr = minAbsMaxScale.Inverse(brr);

        Console.WriteLine(string.Join(", ", brr));
        Console.WriteLine(string.Join(", ", crr));
    }
}