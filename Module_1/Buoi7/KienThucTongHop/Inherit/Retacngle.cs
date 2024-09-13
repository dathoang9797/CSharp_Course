namespace Buoi7;

public class Retacngle : Shape
{
    private double a, b;

    public Retacngle(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override double Area()
    {
        return a * b;
    }

    public override double Perimeter()
    {
        return 2 * (a + b);
    }
}