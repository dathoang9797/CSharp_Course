public class Ellipse
{
    private double R1 { get; set; }
    private double R2 { get; set; }

    public Ellipse(double r1, double r2)
    {
        R1 = r1;
        R2 = r2;
    }

    public double Perimeter()
    {
        return (R1 + R2) * Math.PI;
    }

    public double Area()
    {
        return R1 * R2 * Math.PI;
    }
}