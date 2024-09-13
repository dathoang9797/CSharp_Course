namespace Module_2;

public class Retangle
{
    private double a, b;

    // public Retangle(double a, double b)
    // {
    //     this.a = a;
    //     this.b = b;
    // }
    public Retangle(double a, double b) => (this.a, this.b) = (a, b);

    // public double Area()
    // {
    //     return a * b;
    // }

    public double Area() => a * b;

    public double Perimeter() => 2 * (a + b);

    public double A => a;

    // public double B
    // {
    //     set
    //     {
    //         b = value;
    //     }
    //     get
    //     {
    //         return b;
    //     }
    // }

    public double B
    {
        get => b;
        set => b = value;
    }
}