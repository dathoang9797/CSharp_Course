namespace Buoi8;

public abstract class Scaler
{
    //Native
    // public abstract void Fit(double[] arr);
    // public abstract double[] Transform(double[] arr);
    // public abstract double[] FitTransFrom(double[] arr);
    // public abstract double[] Inverse(double[] arr);

    public abstract void Fit(double[] arr);
    public abstract double CalculateTransFrom(double value);
    public abstract double CalculateInvert(double value);

    double[] Calcultate(double[] arr, Func<double, double> Calc)
    {
        var brr = new double[arr.Length];
        for (var i = 0; i < arr.Length; i++)
        {
            brr[i] = Calc(arr[i]);
        }

        return brr;
    }

    public double[] FitTransFrom(double[] arr)
    {
        Fit(arr);
        return Transform(arr);
    }

    public double[] Transform(double[] arr)
    {
        return Calcultate(arr, CalculateTransFrom);
    }

    public double[] Inverse(double[] arr)
    {
        return Calcultate(arr, CalculateInvert);
    }
}