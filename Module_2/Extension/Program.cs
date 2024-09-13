// See https://aka.ms/new-console-template for more information

using Extensionn;

string Clean(string str)
{
    return str.Replace(" ", "").Trim();
}

var str = "Xin Chao \n";
Console.WriteLine(str.Length);
Console.WriteLine(str.Trim());
Console.WriteLine(str.Trim().Length);
Console.WriteLine(Clean(str));
Console.WriteLine(str.Clean());

int[] arr = { 3, 7, 8, 4, 5 };
Console.WriteLine(arr.Sum());

double[] brr ={3,9.5,6,8,4};
Console.WriteLine(brr.TinhDoLechChuan());

List<double> list = new List<double>()
{
    8,3,8,9,16,21,9.7
};
Console.WriteLine(list.TinhDoLechChuan());