using System;

class Diem
{
    int x, y;

    public Diem(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // Properties
    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public override string ToString()
    {
        return $"{x},{y}";
    }
}