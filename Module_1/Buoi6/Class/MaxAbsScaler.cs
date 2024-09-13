public class MaxAbsScaler
{
    private double Max { get; set; }

    private void Fit(double[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = Math.Abs(arr[i]);
        }

        Console.WriteLine(string.Join(", ", arr));
        Max = arr.Max();
        Console.WriteLine($"Max: {Max}");
    }

    private double[] Transform(double[] arr)
    {
        var brr = new double[arr.Length];
        for (var i = 0; i < arr.Length; i++)
        {
            brr[i] = arr[i] / Max;
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
            brr[i] = arr[i] * Max;
        }

        return brr;
    }
}