namespace Buoi9.BaitapPH;

public class Solution : ISolution
{
    private int ph;

    public Solution(int value)
    {
        ph = value;
    }

    public int GetPH()
    {
        return ph;
    }

    public void SetPH(int value)
    {
        ph = value;
    }
    
    public override string ToString()
    {
        return ph.ToString();
    }
}