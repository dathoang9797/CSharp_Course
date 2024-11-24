namespace ConsoleApp;

public class PhanSo
{
    public int Tu { get; set; }
    public int Mau { get; set; }

    public override string ToString()
    {
        return $"{Tu}/{Mau}";
    }
}