using Buoi8;


public class RobustScaler : Scaler
{
    private double Q1 { get; set; }
    private double Q3 { get; set; }
    private double Mean { get; set; }

    public override void Fit(double[] arr)
    {
        Mean = arr.Average();
        var brr = new double[arr.Length];
        Array.Copy(arr, brr, arr.Length);
        Array.Sort(brr);
        Q1 = brr[arr.Length / 4];
        Q3 = brr[3 * arr.Length / 4];
    }

    public override double CalculateTransFrom(double value)
    {
        return (value - Mean) / (Q3 - Q1);
    }

    public override double CalculateInvert(double value)
    {
        return value * (Q3 - Q1) + Mean;
    }
    
    // public override double[] Transform(double[] arr)
    // {
    //     var brr = new double[arr.Length];
    //     for (var i = 0; i < arr.Length; i++)
    //     {
    //         brr[i] = (arr[i] - Mean) / (Q3 - Q1);
    //     }
    //
    //     return brr;
    // }
    //
    // public override double[] Inverse(double[] arr)
    // {
    //     var brr = new double[arr.Length];
    //     for (var i = 0; i < arr.Length; i++)
    //     {
    //         brr[i] = arr[i] * (Q3 - Q1) + Mean;
    //     }
    //
    //     return brr;
    // }
}