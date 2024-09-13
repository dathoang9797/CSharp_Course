namespace Module_1.Buoi4;

public class Buoi4
{
    public Buoi4()
    {
        //Loai tien: 50, 20, 10, 5, 2, 1
//Input: nhap vao so tien can doi
//Output: in ra so tien doi duoc

System.Console.Write("Nhap so tien can doi: ");
int m = Convert.ToInt32(Console.ReadLine());
//You code here (50, 20, 10, 5, 2, 1)
System.Console.WriteLine($"{m / 50} to 50");
m %= 50;
System.Console.WriteLine($"{m / 20} to 20");
m %= 20;
System.Console.WriteLine($"{m / 10} to 10");
m %= 10;
System.Console.WriteLine($"{m / 5} to 5");
m %= 5;
System.Console.WriteLine($"{m / 2} to 2");
m %= 2;
System.Console.WriteLine($"{m / 1} to 1");
m %= 1;

// int[] arr = {3, 7, 8, 4, 15};
// System.Console.WriteLine(arr.Length);
// long s = 0;
// for(int i = 0; i < arr.Length; i++){
//     System.Console.WriteLine(arr[i]);
//     s += arr[i];
// }
// System.Console.WriteLine($"Tong cac phan tu: {s}");

// double avg = s / (double)arr.Length;
// System.Console.WriteLine($"Trung Binh: {avg}");



// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Loop
//for, foreach, while, do-while

//In ra cac so tu 1 -> 100

// for(int i = 1; i <= 100; i++){
//     System.Console.WriteLine(i);
// }

// System.Console.WriteLine("thoat khoi vong vap");





// System.Console.Write("Nhap n: ");
// int n = Convert.ToInt32(Console.ReadLine());

// double s = 1;
// for(int i = 1; i <= n; i++){
//     s = 1.0 + 1.0 / s;
// }
// System.Console.WriteLine($"Tong: {s}");


//x - x^2 + x^3 - x^4...



// System.Console.Write("Nhap x: ");
// int x = Convert.ToInt32(Console.ReadLine());

// long p = -1, s = 0;
// for(int i = 1; i <= n; i++){
//     p *= -x;
//     s += p;
// }
// System.Console.Write($"{x} - {x}^2  + {x}^3 ... ={s}");

//x - x^2 + x^3 - x^4 


//1! + 3! + 5! + ... + (2n+1)!
// long p = 1, s = 1;
// for(int i = 3; i <= 2 * n + 1; i += 2){
//     p = i * (i - 1) * p;
//     s += p;
// }
// System.Console.WriteLine($"1! + 3! + 5! + ... + {2*n+1}!={s}");


//2! + 4! + 6! + ... + (2n)!
// long p = 1;
// long s = 0;
// for (int i = 2; i <= 2*n; i += 2)
// {
//     p = i * (i - 1) * p;
//     s += p;
// }
// System.Console.WriteLine($"2! + 4! + ... +{2*n}! = {s}");

// p = 1;
// s = 0;
// for(int i = 1; i<= n;i ++){
//     p = 2 * i * (2 * i - 1) * p;
//     s += p;
// }
// System.Console.WriteLine($"2! + 4! + ... +{2*n}! = {s}");




//1! + 2! + ... + n!
// long p = 1;
// long s = 0;
// for(int i = 1; i <= n; i++){
//     p *= i;
//     s += p;
// }
// System.Console.WriteLine($"Tich: 1! + 2! + ... + {n}!={s}");


//Tinh: x^n
// System.Console.Write("Nhap x: ");
// int x = Convert.ToInt32(Console.ReadLine());
// long p = 1;
// for (int i = 1; i <= n; i++){
//     p *= x;
// }
// System.Console.WriteLine($"Tích: p={p}");

// //1/1 + 1/2 + ... + 1/n
// double s = 0;
// for(int i = 1;i <= n; i++){
//     //Naive
//     //s += 1/(double)i;
//     s += 1.0 / i;
// }
// System.Console.WriteLine($"Tong {s}");


// long s = 0;
// for(int i = 1; i <= n; i++){
//     s += i;
// }
// System.Console.WriteLine($"Tong: 1 + 2 + ... + {n} = {s}");

// long s = 0;
// for(int i = 1; i <= n; i++){
//     s += 2 * i;
// }
// System.Console.WriteLine($"Tong: 2 + 4 + ... + {2*n} = {s}");

// s = 0;
// for(int i = 2; i <= 2 * n; i += 2){
//     s += i;
// }
// System.Console.WriteLine($"Tong: 2 + 4 + ... + {2*n} = {s}");


// s = 0;
// for(int i = 1; i <= n; i++){
//     s += i;
// }
// s *= 2;

// System.Console.WriteLine($"Tong: 2 + 4 + ... + {2*n} = {s}");
    }
}