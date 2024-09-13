namespace Buoi10.Baitap_OOP_Market;

public class Food : Subject
{
    private double DongLanh { get; set; }

    public Food(
        short stt, double dienTich, double dongLanh,
        double thue, double donGia
    ) : base(stt, dienTich, thue, donGia)
    {
        DongLanh = dongLanh;
    }

    protected override double ThueDoanhThu()
    {
        return Thue * 0.05;
    }

    public override double TienThue()
    {
        return base.TienThue() + DongLanh;
    }
}