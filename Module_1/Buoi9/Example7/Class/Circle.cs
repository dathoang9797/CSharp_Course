namespace Buoi9;

public class Circle : Ellipse
{
    protected double r;

    public Circle(double r) : base(r, r)
    {
        this.r = r;
    }

    public double Area()
    {
        return Math.PI * r * r;
    }

    public double Perimeter()
    {
        return Math.PI * 2 * r;
    }
}