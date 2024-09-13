// See https://aka.ms/new-console-template for more information

using Module_2;
using Module_2.Buoi1;
using Module_2.Buoi1.Class;
using Module_2.FunctionArrow;

// var buoi1 = new Buoi1();
//
// var functionArrow = new FunctionArrow();

var siteProvider = new SiteProvider();

siteProvider.Category.DoSomeThing();
siteProvider.Category.DoThat();


//Buoi7
double[] arr = { 3.5, 8.3, -7.4, 6.1, 9.1, -10.5 };
// Console.WriteLine(arr.Min());
// Console.WriteLine(arr.Max());

//max abs;
//min abs;

// var maxAbs = Math.Abs(arr[0]);
// foreach (var t in arr)
// {
//     if (maxAbs < Math.Abs(t))
//         maxAbs = Math.Abs(t);
// }
// Console.WriteLine($"Max abs_1 is: {maxAbs}");
//
// var maxAbs2 = arr.Max(p => Math.Abs(p));
// Console.WriteLine($"Max abs_2 is: {maxAbs2}");
//
// double Abs(double v)
// {
//     return Math.Abs(v);
// }
// var maxAbs3 = arr.Max(Abs);
// Console.WriteLine($"Max abs_3 is: {maxAbs3}");

Console.WriteLine(arr.Sum());
Console.WriteLine(arr.Average());
var var1 = arr.Sum(x => x - arr.Average()) / arr.Length;
Console.WriteLine($"Phuong sai: {var1}");

var var2 = arr.Average(x => x - arr.Average());
Console.WriteLine($"Phuong sai: {var2}");

int[] xrr = { 3, 7, 8, 4 };
int[] yrr = { 1, 6, 5, 2 };
//x+y

var srr = xrr.Zip(yrr, (x, y) => x + y).ToArray();
Console.WriteLine(string.Join(", ", srr));

var dot = xrr.Zip(yrr, (x, y) => x * y).Sum();
Console.WriteLine($"Tich vo huong: {dot}");

var consine = dot / Math.Sqrt(xrr.Sum(x => x * x) * yrr.Sum(y => y * y));
Console.WriteLine($"Tính Cosine: {consine}");

var averageXrr = xrr.Average();
var averageYrr = yrr.Average();
var cov = xrr.Zip(yrr, (x, y) => (x - averageXrr) * (y - averageYrr)).Average();
Console.WriteLine($"Hiep Phuong Sai: {cov}");

var corr = xrr.Zip(yrr, (x, y) => (x - averageXrr) * (y - averageYrr)).Sum() /
           Math.Sqrt(xrr.Sum(x => Math.Pow(x - averageXrr, 2)) * yrr.Sum(y => Math.Pow(y - averageYrr, 2)));
Console.WriteLine($"He so tuong quan: {corr}");
