namespace Module_1.Buoi3;

public enum SocialChannel
{
    Facebook = 1,
    Instagram,
}

public class Buoi3
{
    public Buoi3()
    {
        // See https://aka.ms/new-console-template for more information

// int a = 7;
// int b = 8;
// a = b;
// Console.WriteLine($"a={a}, ={b}");
//
// int x = 15;
// int y = 17;
//
// bool t = x == y;
// Console.WriteLine($"t{t}");
// Console.WriteLine(x > y);
// Console.WriteLine(x < y);
// Console.WriteLine(x <= y);
// Console.WriteLine(x >= y);

// int a = 7, b = 15, c = 9;
// Console.WriteLine(a > b && a < c); //false
// Console.WriteLine(a > b || a < c); //true
// Console.WriteLine(!(a > b && a < c)); //true

// bool A = false, B = false, C = false;
// Console.WriteLine(!A && (B && !C));
// Console.WriteLine(!A || !B || !C);
// Console.WriteLine(!(A || B || C));
// Console.WriteLine(!A && B && !C);
// Console.WriteLine(!A || !(B || !C));

// Random random = new Random();
// long b = random.Next(1, 9999);
// long a = b + random.Next(1, 99999999);
// Console.WriteLine($"a={a}, b={b}");
// Console.WriteLine(!(a <= b) && (a * b > 0));

// long a = random.Next(-9999, 9999);
// long b = random.Next(-999999, 999999);
// long n = a + random.Next(0, 99999);
// //
// System.Console.WriteLine($"a={a}, b={b}, c={c}");
// System.Console.WriteLine((a < b) || !((c == a * b) && (c < a)));

// int a = 10;
// int b = 2;
// int n = 130;
//
// if (a != b && n / (a - b) > 90)
// {
//     Console.WriteLine($"statement 1");
// }
// else
// {
//     Console.WriteLine($"statement 2");
// }

//Input: Nhap vao 2 so bat ky
//Output: In ra so lon nhat

// Console.Write($"Nhap a: ");
// float a = Convert.ToSingle(Console.ReadLine());
// Console.Write($"Nhap b: ");
// float b = Convert.ToSingle(Console.ReadLine());
//
// if (a > b)
// {
//     Console.WriteLine($"{a} so lon nhat ");
// }
// else
// {
//     Console.WriteLine($"{b} so lon nhat ");
// }
//
// float m = a;
// if (m < b)
//     m = b;

// Console.WriteLine($"{m} so lon nhat ");

// float max = a > b ? a : b;
// Console.WriteLine($"{max} so lon nhat ");

// Console.WriteLine($"{Math.Max(a,b)} so lon nhat ");


//Input: Nhap vao 3 so bat ky
//Output: In ra so lon nhat

// Console.Write($"Nhap a: ");
// float a = Convert.ToSingle(Console.ReadLine());
// Console.Write($"Nhap b: ");
// float b = Convert.ToSingle(Console.ReadLine());
// Console.Write($"Nhap c: ");
// float c = Convert.ToSingle(Console.ReadLine());
// float m = a;
// if (m < b)
//     m = b;
//
// if (m < c)
//     m = c;
// Console.WriteLine($"{m} so lon nhat ");

// if (a > b && a > c)
// {
//     Console.WriteLine($"{a} so lon nhat ");
// }
// else if (b > a && b > c)
// {
//     Console.WriteLine($"{b} so lon nhat ");
// }
// else
// {
//     Console.WriteLine($"{c} so lon nhat ");
// }

// if (a > b && a > c)
// {
//     Console.WriteLine($"{a} so lon nhat ");
// }
// else if (b > a)
// {
//     Console.WriteLine($"{b} so lon nhat ");
// }
// else
// {
//     Console.WriteLine($"{c} so lon nhat ");
// }

// if (a > b)
// {
//     if (a > c)
//     {
//         Console.WriteLine($"{a} so lon nhat ");
//     }
//     else // a<=c
//     {
//         Console.WriteLine($"{c} so lon nhat ");
//     }
// }
// else //a <=b
// {
//     if (b > c)
//     {
//         Console.WriteLine($"{b} so lon nhat ");
//     }
//     else
//     {
//         Console.WriteLine($"{c} so lon nhat ");
//     }
// }

// float max = a > b ? (a > c ? a : c) : (b > c ? b : c);
// Console.WriteLine($"{max} so lon nhat ");


// Console.WriteLine($"{Math.Max(c, Math.Max(a, b))} so lon nhat ");

// float[] arr = {a,b,c};
// Console.WriteLine($"{arr.Max()} so lon nhat ");

//Input: Nhap vao 2 phan so
//Output: In ra 2 phan so do >, < ,=

// Console.WriteLine($"Nhap phan so thu nhat: ");
// Console.Write($"Nhap tu: ");
// int t1 = Convert.ToInt32(Console.ReadLine());
// Console.Write($"Nhap mau: ");
// int m1 = Convert.ToInt32(Console.ReadLine());
//
// Console.WriteLine($"Nhap phan so thu hai: ");
// Console.Write($"Nhap tu: ");
// int t2 = Convert.ToInt32(Console.ReadLine());
// Console.Write($"Nhap mau: ");
// int m2 = Convert.ToInt32(Console.ReadLine());

// int y = t1 * m2;
// int z = t2 * m1;
// if (y == z)
// {
//     Console.Write($"{t1}/{m1} == {t2}/{m2}");
// }
// else if (y < z)
// {
//     Console.Write($"{t1}/{m1} < {t2}/{m2}");
// }
// else
// {
//     Console.Write($"{t1}/{m1} > {t2}/{m2}");
// }

// char op = '=';
// int t = t1 * m2 - t2 * m1;
// if (t < 0)
// {
//     op = '<';
// }
// else if (t > 0)
// {
//     op = '>';
// }
//
// Console.Write($"{t1}/{m1} {op} {t2}/{m2}");

// char[] arr = { '<', '=', '>' };
// int s = Math.Sign(t1 * m2 - t2 * m1);
// Console.Write($"{t1}/{m1} {arr[s + 1]} {t2}/{m2}");

//Input: Nhap vao diem trung binh
//Output: In ra xep hang cua diem trung binh do
// DTB < 5 : Yeu
// 5<= DTB <6.5 :Trung binh
// 6.5 <= DTB <8 : Kha
// 8<=DTB :Gioi

// Console.Write($"Nhap DTB: ");
// float dtb = Convert.ToSingle(Console.ReadLine());
// if (dtb >= 8)
// {
//     Console.Write($"Gioi");
// }
// else if (dtb >= 6.5)
// {
//     Console.Write($"Kha");
// }
// else if (dtb >= 5)
// {
//     Console.Write($"Trung binh");
// }
// else
// {
//     Console.Write($"Yeu");
// }
    }
}