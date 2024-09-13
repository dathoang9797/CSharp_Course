public class Square
{
    private double A { get; set; }

    public Square(double a)
    {
        A = a;
    }

    public double Perimeter()
    {
        return A * 4;
    }

    public double Area()
    {
        return A * A;
    }
}