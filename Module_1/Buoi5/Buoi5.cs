using System.Text;

namespace Module_1.Buoi5;

public class Buoi5
{
    public Buoi5()
    {
        Console.OutputEncoding = Encoding.Unicode;

// int[] arr = { 7, 9, 16, 24, 43, 28 };
// Console.WriteLine($"So luong phan tu cua mang: {arr.Length}");
//
// long sum = 0;
// for (int i = 0; i < arr.Length; i++)
// {
//     Console.WriteLine(arr[i]);
//     sum += arr[i];
// }
//
// Console.WriteLine($"Tong: {sum}");
// var avg = sum / (double)arr.Length;
// Console.WriteLine($"Gia tri trung binh: {avg.ToString("#,###.00")}");

// int[] arr = [50, 20, 10, 5, 2, 1];
// Console.Write("Nhap so tien can doi: ");
// int m = Convert.ToInt32(Console.ReadLine());
//
// for (int i = 0; i < arr.Length; i++)
// {
//     Console.WriteLine($"{m / arr[i]} to {arr[i]}");
//     m %= arr[i];
// }

//Khoang cach euclide
// int[] listOne = { 3, 7, 8, 4, 9, 15 };
// int[] listTwo = { 1, 5, 3, 8, 4, 1 };
//Tính tích vô hướng
// double Euclide(int[] listOne, int[] listTwo)
// {
//     double s = 0;
//     for (var i = 0; i < listOne.Length; i++)
//     {
//         s += Math.Abs(listOne[i] - listTwo[i]);
//     }
//     return Math.Sqrt(s);
// }
// Console.WriteLine($"Khoang cach euclide {Euclide(listOne,listTwo)}");

//Khoang cach Manhatan
// int[] arr = [3, 7, 8, 4, 9, 15];
// int[] brr = [1, 5, 3, 8, 4, 1];
//
// long Manhantan(int[] listOne, int[] listTwo)
// {
//     long s = 0;
//     for (var i = 0; i < listOne.Length; i++)
//     {
//         s += Math.Abs(listOne[i] - listTwo[i]);
//     }
//
//     return s;
// }
//
// Console.WriteLine($"Khoang cach Manhatan {Manhantan(arr, brr)}")

// double[] x = [2, 3, 2.7, 3.2, 4.1];
// double[] y = [10, 14, 12, 15, 20];

//Trung binh:
// double Average(double[] arr)
// {
//     double value = 0;
//     for (var i = 0; i < arr.Length; i++)
//     {
//         value += arr[i];
//     }
//
//     return value / arr.Length;
// }

//phuong sai
// double Variance(double[] arr)
// {
//     double s = 0;
//     double avg = Average(arr);
//     for (int i = 0; i < arr.Length; i++) //loop
//     {
//         s += Math.Pow(arr[i] - avg, 2);
//     }
//
//     return s / (arr.Length - 1);
// }

//Do lech chuan
// double StandardDeviation(double[] arr) => Math.Sqrt(Variance(arr));

//Hiep phuong sai
// double Covariance(double[] paramX, double[] paramY)
// {
//     double sum = 0;
//     var avgX = Average(paramX);
//     var avgY = Average(paramY);
//     var length = paramX.Length;
//     for (var i = 0; i < length; i++)
//     {
//         var value = (paramX[i] - avgX) * (paramY[i] - avgY);
//         sum += value;
//     }
//
//     sum /= (length - 1);
//     return sum;
// }

//Hệ số tương quan 
// double CorrelationCoefficient(double[] paramX, double[] paramY)
// {
//     double result = 0;
//     var covariance = Covariance(paramX, paramY);
//     var standardDeviationX = StandardDeviation(paramX);
//     var standardDeviationY = StandardDeviation(paramY);
//     result = covariance / (standardDeviationX * standardDeviationY);
//     return result;
// }

// Console.WriteLine($"Trung binh: {Average(x)}");
// Console.WriteLine($"Phuong sai: {Variance(x)}");
// Console.WriteLine($"Do lech chuan: {StandardDeviation(x)}");
// Console.WriteLine($"Hiep phuong sai: {Covariance(x, y):0.00}");
// Console.WriteLine($"He so tuong quan: {CorrelationCoefficient(x, y):0.00}");

//for(index) vs foreach(value)
// int[] arr = [3, 7, 8, 4, 1, 5];
// for (var i = 0; i < arr.Length; i++)
// {
//     Console.WriteLine($"{arr[i]}");
//     arr[i] *= 2;
// }

// foreach (var t in arr)
// {
// Console.WriteLine($"{t}");
// t *= 2;
// }

//List => Dictionary
//Tại sao phải dùng list
//Khi khai báo mảng => kích thước mảng cố định

// int[] arr = new int[3];
// arr[0] = 1;
// arr[1] = 2;
// arr[2] = 3;
// Console.WriteLine(string.Join(", ", arr));

// List<int> list = new List<int>();
// list.Add(3);
// list.Add(4);
// list.Add(5);
// Console.WriteLine(string.Join(", ", list));
//
// list.Remove(4);
// Console.WriteLine(string.Join(", ", list));
//
// list.Add(10);
// list.Add(20);
// list.RemoveAt(0);
// Console.WriteLine(string.Join(", ", list));

//Array điểm yếu
//kích thướng mảng cố định
//index(int) liên tục và dùng kieu so nguyen không dùng được float, double, char, string

//Dictionary => key + value (key == index)
//Key có thể là int, char, double, float, decimal, string, bool

// var dict = new Dictionary<int, string>
// {
//     [1] = "One",
//     [10] = "Ten",
//     [25] = "Tweenty five"
// };
//
// Console.Write("Mời bạn nhập key: ");
// var key = Convert.ToInt32(Console.ReadLine());
// Console.WriteLine(dict.TryGetValue(key, out var value) ? value : "Không tìm thấy key");


//Thống kê tần xuất
// int[] arr = [3, 15, 7, 3, 9, 4, 3, 7, 3, 4];
// var dict = new Dictionary<int, int>();
// foreach (var key in arr)
// {
//     if (dict.ContainsKey(key))
//     {
//         dict[key]++;
//     }
//     else
//     {
//         dict[key] = 1;
//     }
// }
//
// Console.WriteLine(string.Join("\n", dict));
// Console.WriteLine("Gia tri\t Tan xuat");
// foreach (var item in dict)
// {
//     Console.WriteLine($"{item.Key}: \t{item.Value}");
// }

//Bai tap 1 Label Encoder
// string[] colors = ["red", "blue", "white", "red", "white", "blue"];
// var dict = new Dictionary<string, int>();
// var label = 0;
// foreach (var key in colors)
// {
//     if (!dict.ContainsKey(key))
//     {
//         dict[key] = label;
//         label++;
//     }
// }
//
// Console.WriteLine(string.Join("\n", dict));
// var arr = new int[colors.Length];
// for (var i = 0; i < colors.Length; i++)
// {
//     var index = dict[colors[i]];
//     arr[i] = index;
// }
//
// Console.WriteLine(string.Join(", ", arr));

//Bai tap 2 One Hot Encoder
// Gán giá trị one-hot cho mỗi chuỗi trong mảng ban đầu
// Tạo mảng hai chiều để lưu trữ các giá trị one-hot
// var oneHotEncoded = new int[colors.Length, dict.Count];
// Console.WriteLine("One-Hot Encoded Array:");
// var row = oneHotEncoded.GetLength(0);
// var col = oneHotEncoded.GetLength(1);
// Console.WriteLine($"Dong: {row}");
// Console.WriteLine($"Cot: {col}");
// for (var i = 0; i < arr.Length; i++)
// {
//     for (var j = 0; j < dict.Count; j++)
//     {
//         Console.Write(oneHotEncoded[i, j] + " ");
//     }
//
//     Console.WriteLine();
// }
//
// for (var i = 0; i < colors.Length; i++)
// {
//     var key = colors[i];
//     oneHotEncoded[i, dict[key]] = 1;
// }
//
// Console.WriteLine("================================");
//
// for (var i = 0; i < arr.Length; i++)
// {
//     for (var j = 0; j < dict.Count; j++)
//     {
//         Console.Write(oneHotEncoded[i, j] + " ");
//     }
//
//     Console.WriteLine();
// }

//Bai tap Biểu đồ nhánh lá
        int[] data = { 13, 27, 14, 18, 22, 15, 107, 109, 27 };
        var stemAndLeaf = new Dictionary<int, List<int>>();
        foreach (var number in data)
        {
            var stem = number / 10; //nhánh 
            var leaf = number % 10; //lá
            if (!stemAndLeaf.ContainsKey(stem))
            {
                stemAndLeaf[stem] = new List<int> { };
            }

            stemAndLeaf[stem].Add(leaf);
        }

        Console.WriteLine("Stem-and-Leaf Plot:");
        foreach (var kvp in stemAndLeaf)
        {
            Console.Write($"{kvp.Key}: {string.Join(", ", kvp.Value)} ");
            Console.WriteLine();
        }
    }
}