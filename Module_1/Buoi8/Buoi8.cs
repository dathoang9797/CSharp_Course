using Buoi8.Static;

namespace Module_1.Buoi8;

public class Buoi8
{
    public Buoi8()
    {
        // See https://aka.ms/new-console-template for more information


// double[] arr = { 3, 7, 8, 4, 1, 5, 9, 15, 24, 33, 17 };
// var standardScaler = new StandardScaler();
//
// var brr1 = standardScaler.FitTransFrom(arr);
// Console.WriteLine(string.Join(", ", brr1));
//
// var crr1 = standardScaler.Inverse(brr1);
// Console.WriteLine(string.Join(", ", crr1));
//
// Console.WriteLine();
// Console.WriteLine("=======================");
// Console.WriteLine();
//
// var robustScaler = new RobustScaler();
// var brr2 = robustScaler.FitTransFrom(arr);
// Console.WriteLine(string.Join(", ", brr2));
//
// var crr2 = robustScaler.Inverse(brr2);
// Console.WriteLine(string.Join(", ", crr2));

//=================Delegate===================
// void Sort(int[] arr, Compare compare)
// {
//     for (int i = 0; i < arr.Length; i++)
//     {
//         for (int j = 0; j < arr.Length; j++)
//         {
//             if (compare(arr[i], arr[j]))
//             {
//                 // var t = arr[i];
//                 // arr[i] = arr[j];
//                 // arr[j] = t;
//                 (arr[i], arr[j]) = (arr[j], arr[i]);
//             }
//         }
//     }
// }

//Cach 1
// int[] arr = { 3, 7, 6, 1, 4, 15, 23, 41, 8, 17 };
// Sort(arr, Accessin);
// Console.WriteLine(string.Join(", ", arr));
//
// int[] brr = { 3, 7, 6, 1, 4, 15, 23, 41, 8, 17 };
// Sort(brr, Descing);
// Console.WriteLine(string.Join(", ", brr));
//
// bool Accessin(int a, int b)
// {
//     return a < b;
// }
//
// bool Descing(int a, int b)
// {
//     return a > b;
// }

//Cach 2
// void Sort(int[] arr, Func<int, int, bool> compare)
// {
//     for (int i = 0; i < arr.Length; i++)
//     {
//         for (int j = 0; j < arr.Length; j++)
//         {
//             if (compare(arr[i], arr[j]))
//             {
//                 // var t = arr[i];
//                 // arr[i] = arr[j];
//                 // arr[j] = t;
//                 (arr[i], arr[j]) = (arr[j], arr[i]);
//             }
//         }
//     }
// }
//
//
// int[] arr = { 3, 7, 6, 1, 4, 15, 23, 41, 8, 17 };
// Sort(arr, (int a, int b) => a < b);
// Console.WriteLine(string.Join(", ", arr));
//
// int[] brr = { 3, 7, 6, 1, 4, 15, 23, 41, 8, 17 };
// Sort(arr, (int a, int b) => a > b);
// Console.WriteLine(string.Join(", ", brr));
//
// delegate bool Compare(int a, int b);
//=================Delegate===================

//=================Static===================
        var studentOne = new DemoStatic();
        var studentTwo = new DemoStatic();

        studentTwo = new DemoStatic();
//=================Static===================
    }
}