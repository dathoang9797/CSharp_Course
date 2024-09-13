public class Triangle
{
    private double A { get; set; }
    private double B { get; set; }
    private double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double Perimeter()
    {
        return A + B + C;
    }

    public double Area()
    {
        var p = Perimeter();
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }
}