public class Circle
{
    private double R { get; set; }
    public Circle(double r)
    {
        R = r;
    }

    public double Perimeter()
    {
        return Math.PI * R * 2;
    }

    public double Area()
    {
        return Math.PI * R * R;
    }
}