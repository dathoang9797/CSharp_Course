namespace Module_1.Buoi1;

public class Buoi1
{
    public Buoi1()
    {
        Console.Write("Nhap vao ten cua ban: ");
        //string? name = Console.ReadLine();
        //Console.WriteLine("Xin chao ban " + name);

        //Console.Write("Nhap so thu nhat: ");
        //int a = Convert.ToInt32(Console.ReadLine());

        //Console.Write("Nhap so thu hai: ");
        //int b = Convert.ToInt32(Console.ReadLine());


        //Console.WriteLine($"Tong cua a + b la: {a + b}");

        //Console.Write("Nhap vao ban kinh: ");
        double r = Convert.ToDouble(Console.ReadLine());

        double dientich = Math.PI * r * r;
        double chuvi = Math.PI * r * 2;

        //Console.WriteLine($"Chu vi hinh tron la: {chuvi}" );
        //Console.WriteLine($"Dien tich hinh tron la: {dientich}");
        Console.WriteLine($"dien tich la: {dientich.ToString("#,###.00")}, chuvi: {chuvi.ToString("#,###.00")}");
        //Console.WriteLine($"dien tich la: {Math.Round(dientich, 2)}, chuvi: {Math.Round(chuvi, 2)}");


        //Console.Write("Nhap canh a: ");
        //double a = Convert.ToDouble(Console.ReadLine());
        //Console.Write("Nhap canh b: ");
        //double b = Convert.ToDouble(Console.ReadLine());
        //Console.Write("Nhap canh c: ");
        //double c = Convert.ToDouble(Console.ReadLine());

        //double chuvi = a + b + c;
        //double p = chuvi / 2;
        //double dientich = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        //Console.WriteLine($"Chu vi hinh tron la: {chuvi}");
        //Console.WriteLine($"Dien tich hinh tron la: {dientich}");


        //Console.WriteLine("nhap goc bat ky: ");
        //int angle = Convert.ToInt32(Console.ReadLine());

        //Console.WriteLine($"{angle} thuoc goc phan tu: {angle % 360 / 90 + 1}");
        //Console.WriteLine($"{angle} thuoc goc phan tu: {angle / 90 % 4 + 1}");


        //Console.Write("Nhap so dong 1 trang: ");
        //int row = Convert.ToInt32(Console.ReadLine());
        //Console.Write("Nhap kich thuoc cua 1 trang: ");
        //int size = Convert.ToInt32(Console.ReadLine());

        //Console.WriteLine($"Pages: {Math.Ceiling(row / (double)size)}");


        //Console.WriteLine($"Hom nay la thu may: (2, 6)");
        //int Day = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine($"Nhap K: ");
        //int K = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine($"Sau {K} ngay la thu {(Day - 2 + K) % 7 + 2} ");


        Console.Write("Nhap gio: ");
        int hour = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap phut: ");
        int minute = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap giay: ");
        int second = Convert.ToInt32(Console.ReadLine());

        second += 1;
        minute += second / 60;
        hour += minute / 60;
        Console.WriteLine($"{hour % 24} : {minute % 60} : {second % 60}");


        Console.ReadKey();
    }
}