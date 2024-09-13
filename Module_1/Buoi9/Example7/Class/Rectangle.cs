using Buoi9.Example7.Interface;

namespace Buoi9;

public class Rectangle : IShape
{
    private double a, b;

    public Rectangle(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public double Area()
    {
        return a * b;
    }

    public double Perimeter()
    {
        return 2 * (a + b);
    }
}