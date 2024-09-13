public class Rectangle
{
    private double A { get; set; }
    private double B { get; set; }

    public Rectangle(double a, double b)
    {
        A = a;
        B = b;
    }

    public double Perimeter()
    {
        return (A + B) * 2;
    }

    public double Area()
    {
        return A * B;
    }
}