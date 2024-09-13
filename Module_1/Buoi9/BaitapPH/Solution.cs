namespace Buoi9;

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
}