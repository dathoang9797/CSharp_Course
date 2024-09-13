namespace Buoi10.Baitap_OOP_Market;

abstract public class Subject
{
    protected short Stt { get; set; }
    protected double DienTich { get; set; }
    protected double Thue { get; set; }
    protected double DonGia { get; set; }

    public Subject(short stt, double dienTich, double thue, double donGia)
    {
        Stt = stt;
        DienTich = dienTich;
        Thue = thue;
        DonGia = donGia;
    }

    public override string ToString()
    {
        return $"STT {Stt}, Dien tich: {DienTich}";
    }

    private double TienThueSap()
    {
        return DonGia * DienTich;
    }

    public virtual double TienThue()
    {
        return TienThueSap() + ThueDoanhThu();
    }

    protected abstract double ThueDoanhThu();
}