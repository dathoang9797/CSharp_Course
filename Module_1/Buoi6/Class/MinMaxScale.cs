public class MinMaxScale
{
    private double Min { get; set; }
    private double Max { get; set; }

    private void Fit(double[] arr)
    {
        Min = arr.Min();
        Max = arr.Max();
    }

    private double[] Transform(double[] arr)
    {
        var brr = new double[arr.Length];
        for (var i = 0; i < arr.Length; i++)
        {
            brr[i] = (arr[i] - Min) / (Max - Min);
        }

        return brr;
    }

    public double[] FitTransFrom(double[] arr)
    {
        Fit(arr);
        return Transform(arr);
    }

    public double[] Inverse(double[] arr)
    {
        var brr = new double[arr.Length];
        for (var i = 0; i < arr.Length; i++)
        {
            brr[i] = arr[i] * (Max - Min) + Min;
        }

        return brr;
    }
}