namespace Buoi9.BaitapPH;

public class MechanicalArm : IMechanicalArm
{
    private IMechanicalArm _mechanicalArmImplementation;
    private int Index { get; set; }
    private bool IsFacingRight { get; set; }

    public MechanicalArm(int index, bool isFacingRight)
    {
        Index = index;
        IsFacingRight = isFacingRight;
    }

    public int GetCurrentIndex()
    {
        return Index;
    }

    public bool CheckIsFacingRight()
    {
        return IsFacingRight;
    }

    public void ChangeDirection()
    {
        IsFacingRight = !IsFacingRight;
    }

    public void MoveForward(int numLocation)
    {
        if (IsFacingRight)
        {
            Index += numLocation;
        }
        else
        {
            Index -= numLocation;
        }
    }
}