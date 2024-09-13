namespace Extensionn;

public static class Util
{
    public static string Clean(this string str)
    {
        return str.Replace(" ", "").Trim();
    }

    public static double TinhDoLechChuan(this IEnumerable<double> arr)
    {
        var average = arr.Average();
        return Math.Sqrt(arr.Average(x => Math.Pow(x - average, 2)));
    }
}