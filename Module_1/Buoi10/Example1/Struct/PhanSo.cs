using System;

struct PhanSo
{
    int tu;
    int mau;

    public PhanSo(int tu, int mau)
    {
        this.tu = tu;
        this.mau = mau;
    }

    // Properties
    public int Tu
    {
        get { return tu; }
        set { tu = value; }
    }

    public int Mau
    {
        get { return mau; }
        set { mau = value; }
    }

    public override string ToString()
    {
        return $"{tu}/{mau}";
    }
}