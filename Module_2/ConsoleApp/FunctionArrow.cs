namespace Module_2.FunctionArrow;

public class FunctionArrow
{
    public FunctionArrow()
    {
        Console.WriteLine(Sum(3, 7, 8));
        Console.WriteLine(Sum2(3, 7, 8));

        int[] arr = { 7, 9, 1, 6, 4 };
        Print(arr);
        Print2(arr);
    }

    double Sum(double a, double b, double c)
    {
        return a + b + c;
    }

    double Sum2(double a, double b, double c) => a + b + c;

    void Print(int[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    void Print2(int[] arr) => Console.WriteLine(string.Join(", ", arr));
}