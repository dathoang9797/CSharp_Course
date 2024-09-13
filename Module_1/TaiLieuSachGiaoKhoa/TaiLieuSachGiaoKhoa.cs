using System.Text;

namespace Module_1.TaiLieuSachGiaoKhoa;

public class TaiLieuSachGiaoKhoa
{
    public TaiLieuSachGiaoKhoa()
    {
        #region Struct

// struct SinhVien
// {
//     public string HoTen;
//     public DateTime NgaySinh;
//     public bool GioiTinh;
//     public int HocBong;
//
//     public SinhVien(string hoTen, DateTime ngaySinh, bool gioiTinh, int hocBong)
//     {
//         HoTen = hoTen;
//         NgaySinh = ngaySinh;
//         GioiTinh = gioiTinh;
//         HocBong = hocBong;
//     }
// }
//         SinhVien sinhVien;
//         // sinhVien.HoTen = "Hoang Quy Dat";
//         // sinhVien.GioiTinh = true;
//         // sinhVien.HocBong = 5_000_000;
//         // sinhVien.NgaySinh = new DateTime(1997, 10, 29);
//
//         sinhVien = new SinhVien("Hoang Quy Dat", new DateTime(1997, 10, 29), true, 5_000_000);
//
//         //Tính tuổi
//         int tuoi = DateTime.Today.Year - sinhVien.NgaySinh.Year;
//         Console.WriteLine($@" 
// Họ tên: {sinhVien.HoTen} 
// Ngày sinh: {sinhVien.NgaySinh}  
// Gioi tinh: {sinhVien.GioiTinh}
// Gioi tinh: {sinhVien.GioiTinh} 
// Tuoi: {tuoi}  
// Hoc Bong: {sinhVien.HocBong}");

        #endregion

        #region Enum

// Colors color = Colors.Read;
// Console.WriteLine($"Color: {color}");
//
// int i = (int)color;
// Console.WriteLine($"i: {i}");
//
// enum Colors
// {
//     Read,
//     Geen,
//     Blue,
//     Yellow,
//     Black,
//     White
// }
//
// enum Directions
// {
//     Up,
//     Down,
//     Right,
//     Left,
//     Random
// }
//
// enum Orientation
// {
//     North,
//     South,
//     East,
//     West
// }

        #endregion

        #region Lambda Expression

// Func<int, int> square = x => x * x;
// Console.WriteLine($"{square(4)}");

// Func<double, double> cube = x => x * x * x;
// Console.WriteLine($"{cube(3)}");

        #endregion

        #region Nameof Expression

//
// Func<int, int, bool> testForEquality = (x, y) => x == y;
// Console.WriteLine($"{nameof(testForEquality)}");

        #endregion

        #region Switch Expression

// var direction = Directions.Down;
// Console.WriteLine($"Map view direction is {direction}");
//
// var orientation = direction switch
// {
//     Directions.Up => Orientation.North,
//     Directions.Right => Orientation.East,
//     Directions.Down => Orientation.South,
//     Directions.Left => Orientation.West,
//     _ => throw new NotImplementedException(),
// };
//
// Console.WriteLine($"Cardinal orientation is {orientation}");

        #endregion

        #region With Expression

// record NamedPoint(string Name, int X, int Y);
// var p1 = new NamedPoint("A", 0, 0);
// Console.WriteLine($"{nameof(p1)}: {p1}");
//
// var p2 = p1 with { Name = "B", X = 5 };
// Console.WriteLine($"{nameof(p2)}: {p2}");
//
// var p3 = p1 with { Name = "C", Y = 4 };
// Console.WriteLine($"{nameof(p3)}: {p3}");
//
// Console.WriteLine($"{nameof(p1)}: {p1}");

        #endregion

        #region Class Math

// Console.WriteLine($"Lấy giá trị tuyệt đối: {Math.Abs(-5.2)}");
// Console.WriteLine($"Làm tròn đến số nguyên nhỏ nhất của cận trên: {Math.Ceiling(4.8)}");
// Console.WriteLine($"Làm tròn đến số nguyên lớn nhất của cận dưới: {Math.Floor(4.8)}");
// Console.WriteLine($"Nâng một số double lên lũy thừa: {Math.Pow(3, 2)}");
// Console.WriteLine($"Làm tròn phần nguyên: {Math.Round(4.6)}");
// Console.WriteLine($"Làm tròn phần lẻ: {Math.Round(4.675, 2)}");
// Console.WriteLine($"Lấy căng bậc 2: {Math.Sqrt(9)}");

        #endregion

        #region Thao tác trên chuỗi

// var chuoiOne = "hello, my name  steven";
// Console.WriteLine($"Đổi sang chữ hoa: {chuoiOne.ToUpper()}");
//
// var chuoiTwo = "HELLO, MY NAME IS STEVENT";
// Console.WriteLine($"Đổi sang chữ thường: {chuoiTwo.ToLower()}");
//
// var chuoiThree = "HELLO, MY NAME IS STEVENT";
// Console.WriteLine($"Đổi sang chữ hoa: {chuoiThree.Length}");
//
// var chuoiFour = "HELLO, MY NAME IS STEVENT";
// Console.WriteLine($"Đổi sang chữ hoa: {chuoiFour.Contains("ENT")}");

        #endregion

        #region Thao tác ngày

// var ngaySinh = new DateTime(1997, 10, 29);
// Console.WriteLine($"Ngày sinh {ngaySinh}");
// Console.WriteLine($"Lấy thời gian hiện tại: {DateTime.Now}");
// Console.WriteLine($"Time thời gian UTC hiện tại: {DateTime.UtcNow}");
// Console.WriteLine($"Ngày hiện tại: {DateTime.Today}");
// Console.WriteLine($"Ngày: {DateTime.Today.Day}");
// Console.WriteLine($"Tháng: {DateTime.Today.Month}");
// Console.WriteLine($"Năm: {DateTime.Today.Year}");
// Console.WriteLine($"Hôm qua: {DateTime.Today.AddDays(-1)}");
// Console.WriteLine($"Ngày mai: {DateTime.Today.AddDays(1)}");
// Console.WriteLine($"Số ngày: {DateTime.DaysInMonth(2018, 2)}");
// Console.WriteLine($"Ngày Min: {DateTime.MinValue}");
// Console.WriteLine($"Ngày Max: {DateTime.MaxValue}");
// Console.WriteLine($"Xét có năm nhuận: {DateTime.IsLeapYear(2018)}");

        #endregion

        #region Cấu trúc rẽ nhánh

//
// string thongBao = string.Empty;
// object[] danhSach = { 8, "VB", 23.45, "C#", 3, false };
// foreach (var giaTri in danhSach)
// {
//     switch (giaTri)
//     {
//         case int i:
//         {
//             if (i % 2 == 0)
//             {
//                 thongBao += $"{i} là số chẵn\n";
//             }
//             else
//             {
//                 thongBao += $"{i} là số lẻ\n";
//             }
//
//             break;
//         }
//         case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
//         {
//             thongBao += $"Ngôn ngữ lập trình VB rấ dễ học\n";
//             break;
//         }
//         case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
//         {
//             thongBao += $"Ngôn ngữ lập trình C# rất hay nhung khó học\n";
//             break;
//         }
//         case double d:
//         {
//             thongBao += $"Số thực: {d}.\n";
//             break;
//         }
//         case bool isFalse:
//         {
//             thongBao += $"False: {isFalse}.\n";
//             break;
//         }
//         default:
//         {
//             thongBao += "Chưa biết.\n";
//             break;
//         }
//     }
// }
//
// Console.WriteLine(thongBao);

        #endregion

        #region Function

// void tinhDienTichChuViTamGiac(double a, double b, double c)
// {
//     //Kiểm tra a,b,c có là 3 canh của tam giác
//     bool isValid = (a + b) > c && (b + c) > a && (a + c) > b;
//     if (!isValid)
//     {
//         Console.WriteLine("Không phải tam giác");
//         return;
//     }
//
//     Console.WriteLine($"Tam giác: a={a}, b={b}, c={c}");
//     var chuVi = a + b + c;
//     Console.WriteLine($"Chu vi: {chuVi.ToString("#,#.00")}");
//
//     var p = chuVi / 2;
//     var dienTich = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
//     Console.WriteLine($"Dien tich: {dienTich.ToString("#,#.00")}");
// }

// void doiCho(ref int a, ref int b)
// {
//     // int t = a;
//     // a = b;
//     // b = t;
//     (a, b) = (b, a); // Like above
// }
//
// int a = 7;
// int b = 9;
// Console.WriteLine($"Trước khi gọi làm: a = {a} và b = {b}");
// doiCho(ref a, ref b);
// Console.WriteLine($"Sau khi gọi làm: a = {a} và b = {b}");

// void tinhTong(int a, int b, out int tong)
// {
//     tong = a + b;
// }
//
// int a = 12, b = 5;
// tinhTong(a, b, out var tong);
// Console.WriteLine(tong);

// void dinhDangSoDienThoai(ref string soDienThoai)
// {
//     soDienThoai = soDienThoai.Substring(0, 3) + "-" + soDienThoai.Substring(3, 3) + "-" +
//                   soDienThoai.Substring(6, 4);
// }
//
// string soDienThoai = "0915678987";
// Console.WriteLine(soDienThoai);
// dinhDangSoDienThoai(ref soDienThoai);
// Console.WriteLine(soDienThoai);

// int tinhTong(params int[] cacSo)
// {
//     int tong = 0;
//     foreach (var so in cacSo)
//     {
//         tong += so;
//     }
//
//     return tong;
// }
//
// int tong = tinhTong(1, 2, 3, 4, 5);
// Console.WriteLine(tong);

// tinhDienTichChuViTamGiac(3, 5, 6);

        #endregion

        #region Kiểu Tuple

//Biến hocSinh có kiểu Tuple gồm id, tên, giới tính
// (int id, string ten, bool gioiTinh) hocSinh = (1, "Qúy Đạt", false);
// string chuoi = string.Empty;
// chuoi += $"Id: {hocSinh.id}";
// chuoi += $"\nTên: {hocSinh.ten}";
// chuoi += $"\nGioi tinh: {hocSinh.gioiTinh}";
// Console.WriteLine(chuoi);

// (double? x, string thongBao) GiaiPTBacNhat(double a, double b)
// {
//     if (a != 0)
//     {
//         var x = -b / a;
//         var thongBao = $"Pt có nghiệm duy nhất x = {x}";
//         return (x, thongBao);
//     }
//     else if (b == 0)
//     {
//         double? x = null;
//         var thongBao = "Pt có vô số nghiệm";
//         return (x, thongBao);
//     }
//     else
//     {
//         double? x = null;
//         var thongBao = "Pt vô nghiệm";
//         return (x, thongBao);
//     }
// }
//
// var a = -2;
// var b = 3;
// var (x, thongBao) = GiaiPTBacNhat(a, b);
// var chuoiIn = $"PT: {a}x + {b}";
// chuoiIn += "\n" + thongBao;
// Console.WriteLine(chuoiIn);

// string[] strings = { "Hoàng Lan", "Thúy Ngọc", "Bạch Cúc", " Mỹ Thanh", "Xuân Lan" };
//
// ref string FindString(string target)
// {
//     for (var i = 0; i < strings.Length; i++)
//     {
//         if (strings[i].Contains(target))
//         {
//             return ref strings[i];
//         }
//     }
//
//     return ref strings[0];
// }
//
// var thongBao = $"Trước: {string.Join(", ", strings)}";
// var n = "Cúc";
// ref var value = ref FindString(n);
// value = value.ToUpper();
// thongBao += $"\nSau: " + string.Join(", ", strings);
// Console.WriteLine(thongBao);

        #endregion

        #region Mảng 2 chiêu

//
// var danhSachHoTen = new string[,]
// {
//     { "Nguyễn Hoàng", "Anh" },
//     { "Hoàng Qúy", "Đạt" },
//     { "Phạm Hoàng", "Vy" },
// };
//
// Console.WriteLine(danhSachHoTen.GetLength(0));
// for (var i = 0; i < danhSachHoTen.GetLength(0); i++)
// {
//     Console.WriteLine($"{danhSachHoTen[i, 0]} {danhSachHoTen[i, 1]}");
// }

        #endregion

        #region Mảng của mảng (Jagged Array)

// string[][] danhSachHocVien2;
// danhSachHocVien2 = new string[3][];
// danhSachHocVien2[0] = new[] { "Lê Thị Phương Anh", "phuonganh@gmail.com" };
// danhSachHocVien2[1] = new[] { "Hoàng Qúy Đạt", "dathoang@gmail.com", "dathoang97@gmail.com", "dathoangharavan@gmail.com" };
// danhSachHocVien2[2] = new[] { "Phạm Hoàng Vy", "vy@gmail.com" };
// foreach (var hocVien in danhSachHocVien2)
// {
//     Console.WriteLine(string.Join(", ", hocVien));
// }

        #endregion

        #region Try Catch

// var a = 10;
// var b = 0;
// var thongBao = string.Empty;
// try
// {
//     var c = a / b;
//     thongBao = $"Kết quả {c}";
// }
// catch (DivideByZeroException e)
// {
//     thongBao = $"Lỗi chia cho b = 0";
// }
// catch (Exception e)
// {
//     thongBao = $"{e.Message}";
// }
// Console.WriteLine(thongBao);

// try
// {
//     var c = a / b;
//     thongBao = $"Kết quả {c}";
// }
// catch (DivideByZeroException e)
// {
//     thongBao = $"Lỗi chia cho b = 0";
// }
// catch (Exception e)
// {
//     thongBao = $"{e.Message}";
// }
// finally
// {
//     Console.WriteLine("Kết thúc phép chia");
// }
// Console.WriteLine(thongBao);

// string thongBao;
// string? chuoiSo = "@#@!3";
// try
// {
//     var soNguyen = int.Parse(chuoiSo);
//     thongBao = $"Số nguyên {soNguyen}";
// }
// catch (FormatException e)
// {
//     thongBao = $"Lỗi: không phải là chuỗi số";
// }
// catch (Exception e) when (e.Data == null)
// {
//     thongBao = $"Lỗi: chuỗi số không được null";
// }
// catch (Exception e)
// {
//     thongBao = $"Lỗi: {e.Message}";
// }
//
// Console.WriteLine(thongBao);

        #endregion

        #region Class

//
// var nv1 = new NhanVien();
// var nv2 = new NhanVien("2", "Vy");
//
// Console.WriteLine(nv1.HoVaTen);
// Console.WriteLine(nv2.HoVaTen);
//
// class NhanVien
// {
//     public string MaNhanVien { get; set; }
//     public string HoVaTen { get; set; }
//
//     public NhanVien()
//     {
//         MaNhanVien = "1";
//         HoVaTen = "Dat";
//     }
//
//     public NhanVien(string maNhanVien, string hoVaTen)
//     {
//         MaNhanVien = maNhanVien;
//         HoVaTen = hoVaTen;
//     }
// }

        #endregion

        #region arithmetic operators nạp chồng toán tử

// var a = new Fraction(5, 4);
// var b = new Fraction(1, 2);
// var c = -a;
// var resultSum = a + b;
// var resultMinus = a - b;
// var resultMulti = a * b;
// var resultDivi = a / b;
//
// //Without override ToString
// Console.WriteLine($"{c.Num} / {c.Den}"); // output: -5 / 4
// Console.WriteLine($"{resultSum.Num} / {resultSum.Den}"); // output: 14 / 8
// Console.WriteLine($"{resultMinus.Num} / {resultMinus.Den}"); // output: 6 / 8
// Console.WriteLine($"{resultMulti.Num} / {resultMulti.Den}"); // output: 5 / 8
// Console.WriteLine($"{resultDivi.Num} / {resultDivi.Den}"); // output: 10 / 4
// Console.WriteLine("==================="); // output: -5 / 4
// //Override ToString
// Console.WriteLine(-a); // output: -5 / 4
// Console.WriteLine(a + b); // output: 14 / 8
// Console.WriteLine(a - b); // output: 6 / 8
// Console.WriteLine(a * b); // output: 5 / 8
// Console.WriteLine(a / b); // output: 10 / 4
//
// internal class Fraction
// {
//     public readonly int Num;
//     public readonly int Den;
//
//     public Fraction(int numerator, int denominator)
//     {
//         if (denominator == 0)
//         {
//             throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
//         }
//
//         Num = numerator; //tử số
//         Den = denominator; // mẫu số
//     }
//
//     public static Fraction operator -(Fraction a) => new Fraction(-a.Num, a.Den);
//
//     public static Fraction operator +(Fraction a, Fraction b) =>
//         new Fraction(a.Num * b.Den + b.Num * a.Den, a.Den * b.Den);
//
//     public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
//     public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.Num * b.Num, a.Den * b.Den);
//
//     public static Fraction operator /(Fraction a, Fraction b)
//     {
//         if (b.Num == 0)
//         {
//             throw new DivideByZeroException();
//         }
//
//         return new Fraction(a.Num * b.Den, a.Den * b.Num);
//     }
//
//     public override string ToString() => $"{Num} / {Den}";
// }

        #endregion

        #region Từ khóa static

// var tom = new Person("Tom");
// var jane = new Person("Jane");
// var x = Person.Count;
// var name1 = tom.Name;
// var name2 = jane.Name;
// Console.WriteLine(x);
// Console.WriteLine(name1);
// Console.WriteLine(name2);
// Console.WriteLine(Person.baseline);
// Person.DoSomeThing();

// static class Person //static class không thể khởi tạo một instance
// class Person
// {
// Biến static sẽ tự động có giá trị khi thực thi phương thức khởi tạo static
// public static readonly long baseline;

//Phương thức khởi tạo Static chỉ được thực hiện một lần trước khi tạo đối tượng đầu tiên của lớp Person
// static Person()
// {
// baseline = DateTime.Now.Ticks;
// }
//
// public static int Count { get; set; } = 0; //static
// public string Name { get; set; }
//
// public Person(string name)
// {
//     Name = name;
//     Count += 1;
// }
//
// public static void DoSomeThing() //static
// {
//     Console.WriteLine("Do Some Thing");
// }
// }
//

        #endregion

        #region Khai báo object kiểu vô danh

// var sinhVien = new { Ma = 100, Hoten = "Hoang Quy Dat" };
// var sinhVien2 = sinhVien;
// Console.WriteLine(sinhVien.Ma);
// Console.WriteLine(sinhVien.Hoten);

        #endregion

        #region Expression bodies member

// void ChuoiThongTin() => Console.WriteLine($"Hello");
// ChuoiThongTin();
//
// public class Person
// {
//     private string hoTen;
//     private string Name => hoTen;
//
//     public Person(string hoTen) => this.hoTen = hoTen;
//
//     public string HoTen
//     {
//         get => hoTen;
//         set => hoTen = value;
//     }
// }

        #endregion

        #region Delegate

        // ShowLog log = null;
        // log = Info;
        // log?.Invoke("Hello 2");
        // delegate tham chieu nhieu doi tuong
        // log += Info;
        // log += Info;
        // log += Info;
        // log += Warning;
        // log += Warning;
        // log?.Invoke("Hello 1");

        //Action, Func: delegate - generic
        // delegate (Type) bien = phuongthuc
        // var Tong = (int x, int y) => x + y;
        // var myDeletage = new Pheptinh(Tong);
        // Console.WriteLine(myDeletage(2, 5));
        // public delegate int Pheptinh(int x, int y);
        // Action action; //~ delegate void KIEU();
        // Action<string, int> action1; // ~delegate void KIEU(string s, int i)
        // Action<string> action2; // ~delegate void KIEU(string s)
        // action2 = Warning;
        // action2 += Info;
        // action2?.Invoke("Thong bao tu action");

        //FUNC
        // Func<int> f1; // ~ delegate trả về kiểu int KIEU();
        // Func<string, double, string> f2; // ~ delegate trả về kiểu string KIEU();
        // Func<int, int, int> tinhToan;
        // var a = 5;
        // var b = 10;
        // tinhToan = Tong;
        // Console.WriteLine($"Tổng là: {tinhToan(a, b)}");
        // tinhToan = Hieu;
        // Console.WriteLine($"Hiệu là: {tinhToan(a, b)}");
        // Tong(a, b, Info);
        // Hieu(a, b, Info);

        #endregion

        #region Lamba

        //Lambda - Anonymous function
        //Cách 1: (tham_so) => bieu_thuc
        //Cách 2: (tham_so) => cac bieu_thuc return bieu_thuc_tra_ve;
        // Action<string> thongBao1;
        // thongBao1 = (string s) => Console.WriteLine(s);
        // thongBao1 = s => Console.WriteLine(s);
        // thongBao1.Invoke("Xin chao thong bao 1");

        // Action thongBao2;
        // thongBao2 = () => Console.WriteLine("Xin chao thong bao 2");
        // thongBao2.Invoke();
        //
        // Action<string, string> thongBao3;
        // thongBao3 = (mgs, name) => Console.WriteLine(mgs + " " + name);
        // thongBao3.Invoke("Xin chao", "thong bao 3");
        // Console.WriteLine("===================================");
        // Action<string, string> thongBao4;
        // thongBao4 = (mgs, name) =>
        // {
        //     Console.ForegroundColor = ConsoleColor.Blue;
        //     Console.WriteLine(mgs + " " + name);
        //     Console.ResetColor();
        // };
        // thongBao4.Invoke("Xin chao", "thong bao 4");
        // Console.WriteLine("===================================");
        // Func<int, int, int> tinhToan;
        // tinhToan = (a, b) =>
        // {
        //     var kq = a + b;
        //     return kq;
        // };
        // Console.WriteLine(tinhToan.Invoke(10, 10));
        // Console.WriteLine("===================================");
        // int[] mang = { 2, 4, 64, 5, 7, 8, 9, 33, 55 };
        // var kq1 = mang.Select(i => Math.Sqrt(i));
        // Console.WriteLine(string.Join(", ", kq1));
        // Console.WriteLine("===================================");
        // var kq2 = new List<int>();
        // mang.ToList().ForEach(i =>
        // {
        //     if (i % 2 != 0)
        //         kq2.Add(i);
        // });
        // Console.WriteLine(string.Join(", ", kq2));
        // Console.WriteLine("===================================");
        // var kq3 = mang.Where(i => i % 4 == 0);
        // Console.WriteLine(string.Join(", ", kq3));

        #endregion

        #region Event

        //Dùng để gởi thông điệp từ một lớp đến các lớp khác
        //Lớp gửi thông điệp gọi là Publisher
        //Lớp nhận và xử lý thông điệp là Subcriber

        Console.CancelKeyPress += (sender, e) =>
        {
            Console.WriteLine();
            Console.WriteLine("Thoat ung dung");
        };

        //Publisher
        var userInput = new UserInput();
        userInput.SuKienNhapSo += (object sender, EventArgs e) =>
        {
            var duLieuNhap = (DuLieuNhap)e;
            var x = duLieuNhap.Data;
            Console.WriteLine($"Ban vua nhap so: {x}");
        };

        //Subcriber
        var can = new Can();
        can.Sub(userInput);

        var binhPhuong = new BinhPhuong();
        binhPhuong.Sub(userInput);

        userInput.Input();

        #endregion
        
        #region Collections
        //Collections(tập hợp) là các lớp hỗ trợ thu nhập và quản lý các đối tượng
        //Một cách có thứ tự
        //Hỗ trợ lưu, tìm kiếm và duyệt các đối tượng trogn tập hợp
        //Namespace System.Collections của .NET Framework cung cấp nhiều kiểu tập hợp khác nhau như: ArrayList, SortedList, Hashtable,...
        //ArrayList
         //- ArrayList là 1 tập hợp các phần tử được lưu trữ và truy xuất có thứ tự
         //- Nhiều kiểu dữ liệu khác nhau có thể được lưu trong ArrayList
         //- Các phần tử trong ArrayList được quản lý thông qua chỉ số (index) và giá trị (value)
        //Method ArrayList
         //- Add, AddRange
         #endregion
    }

    #region Delegate

    static int Tong(int a, int b) => a + b;
    static int Hieu(int a, int b) => a - b;

    static void Tong(int a, int b, ShowLog log)
    {
        var kq = a + b;
        log.Invoke($"Tổng là: {kq}");
    }

    static void Hieu(int a, int b, ShowLog log)
    {
        var kq = a - b;
        log.Invoke($"Hieu là: {kq}");
    }

    public delegate void ShowLog(string message);

    public void Info(string s)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(s);
        Console.ResetColor();
    }

    public void Warning(string s)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(s);
        Console.ResetColor();
    }

    #endregion

    #region Event

    class DuLieuNhap : EventArgs
    {
        public int Data { set; get; }
        public DuLieuNhap(int x) => Data = x;
    }

    public delegate void SuKienNhapSoDelegate(int x);

    class UserInput
    {
        // public event SuKienNhapSoDelegate SuKienNhapSo;
        public event EventHandler SuKienNhapSo; // Tương đương delegate void KIEU(object? sender, EventArgs args)

        public void Input()
        {
            do
            {
                Console.WriteLine("Nhap vao so nguyen:");
                var s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s))
                {
                    var i = int.Parse(s);
                    //Phat su kien publisher
                    SuKienNhapSo?.Invoke(this, new DuLieuNhap(i));
                }
            } while (true);
        }
    }


    class Can
    {
        public void Sub(UserInput intput)
        {
            intput.SuKienNhapSo += TinhCan;
        }


        // private void TinhCan(int i)
        // {
        //     Console.WriteLine($"Can bac hai cua {i} la {Math.Sqrt(i)}");
        // }

        private void TinhCan(object sender, EventArgs e)
        {
            var duLieuNhap = (DuLieuNhap)e;
            var i = duLieuNhap.Data;
            Console.WriteLine($"Can bac hai cua {i} la {Math.Sqrt(i)}");
        }
    }

    class BinhPhuong
    {
        public void Sub(UserInput intput)
        {
            intput.SuKienNhapSo += TinhBinhPhuong;
        }

        // private void TinhBinhPhuong(int i)
        // {
        //     Console.WriteLine($"Binh phuong cua {i} la {i * i}");
        // }

        private void TinhBinhPhuong(object? sender, EventArgs e)
        {
            var duLieuNhap = (DuLieuNhap)e;
            var i = duLieuNhap.Data;
            Console.WriteLine($"Binh phuong cua {i} la {i * i}");
        }
    }

    #endregion
}