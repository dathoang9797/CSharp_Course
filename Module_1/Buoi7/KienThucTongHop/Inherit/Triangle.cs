namespace Buoi7;
public class Triangle : Shape
{
    private double a, b, c;

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double Area()
    {
        var p = Perimeter();
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public override double Perimeter()
    {
        return a + b + c;
    }
}