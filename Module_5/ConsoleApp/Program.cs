// See https://aka.ms/new-console-template for more information

//Object vs Dynamic
//ADO.net

//Lưu được mọi kiểu dữ liệu

using System.Runtime.Intrinsics.X86;
using ConsoleApp;

// object a = 7; //interger
// object b = 7.8; //double
// object c = 7.3f; //float
// object d = 9.75d; //decimal
// object s = "xinh chao"; //string
// object ch = 'A'; //character
// object obj = new PhanSo(); //class

// int x = 7;
// double y = 9;
// Console.WriteLine(x + y);
// Console.WriteLine((int)a + (double)b);
// Console.WriteLine(s);

// object x = 7.3f;
// Console.WriteLine(x.GetType());

//Single == float
//Double == double
// double y = (double)x; //error
// double y = Convert.ToDouble(x);
// Console.WriteLine(y);

// float z = (float)x;
// Console.WriteLine(z);

//Object là kiểu đầu tiên trong C#

//ViewData => Object => In ra kết quả
//ViewBag => Dynamic => Tính toán

//Dynamic
dynamic a = 7;
dynamic b = 9.6;
Console.WriteLine(a + b);

//object
var listObject = new List<PhanSo>()
{
    new PhanSo() { Tu = 1, Mau = 2 },
    new PhanSo() { Tu = 2, Mau = 4 },
    new PhanSo() { Tu = 4, Mau = 3 },
    new PhanSo() { Tu = 5, Mau = 5 },
    new PhanSo() { Tu = 7, Mau = 4 }
};

object listPhanSo = listObject;
//Ép kiểu
foreach (var item in (List<PhanSo>)listPhanSo)
{
    Console.WriteLine(item);
}

Console.WriteLine("===========================");
dynamic listPhanSo2 = listObject;
foreach (var item in listPhanSo2)
{
    Console.WriteLine(item);
}

object title = "Web App Store";

Console.WriteLine(title);

dynamic title2 ="Web App Store";
Console.WriteLine(title2);
