using Buoi9.Example7.Interface;

namespace Buoi9;

public class Ellipse : IShape
{
    private double r1;
    private double r2;

    public Ellipse(double r1, double r2)
    {
        this.r1 = r1;
        this.r2 = r2;
    }

    public double Area()
    {
        return Math.PI * r1 * r2;
    }

    public double Perimeter()
    {
        return Math.PI * (r1 * r2);
    }
}