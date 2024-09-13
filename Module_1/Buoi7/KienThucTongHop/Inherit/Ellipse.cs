namespace Buoi7;

public class Ellipse : Shape
{
    private double r1;
    private double r2;

    public Ellipse(double r1, double r2)
    {
        this.r1 = r1;
        this.r2 = r2;
    }

    public override double Area()
    {
        return Math.PI * r1 * r2;
    }

    public override double Perimeter()
    {
        return Math.PI * (r1 * r2);
    }
}