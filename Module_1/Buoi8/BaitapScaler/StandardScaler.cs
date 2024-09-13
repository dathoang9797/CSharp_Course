namespace Buoi8;

public class StandardScaler : Scaler
{
    private double Avg { get; set; }
    private double Stdv { get; set; }

    public override void Fit(double[] arr)
    {
        this.Avg = arr.Average();
        Stdv = 0;
        foreach (var item in arr)
        {
            Stdv += Math.Pow(item - Avg, 2);
        }

        Stdv = Math.Sqrt(Stdv / arr.Length);
    }

    public override double CalculateTransFrom(double value)
    {
        return (value - Avg) / Stdv;
    }

    public override double CalculateInvert(double value)
    {
        return value * Stdv + Avg;
    }

    // private override double[] Transform(double[] arr)
    // {
    //     var brr = new double[arr.Length];
    //     for (var i = 0; i < arr.Length; i++)
    //     {
    //         brr[i] = (arr[i] - Avg) / Stdv;
    //     }
    //
    //     return brr;
    // }
    //

    //
    // public double[] Inverse(double[] arr)
    // {
    //     var brr = new double[arr.Length];
    //     for (var i = 0; i < arr.Length; i++)
    //     {
    //         brr[i] = arr[i] * Stdv + Avg;
    //     }
    //
    //     return brr;
    // }
}