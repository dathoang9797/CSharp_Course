using Buoi9.Example7.Interface;

namespace Buoi9;

public class Triangle : IShape
{
    private double a, b, c;

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double Area()
    {
        var p = Perimeter();
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public double Perimeter()
    {
        return a + b + c;
    }
}