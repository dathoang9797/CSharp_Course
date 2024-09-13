namespace Buoi9.BaitapPH;

public class Experiment
{
    private IMechanicalArm Arm { get; set; }
    private List<ISolution> Solutions { get; set; }

    public Experiment(IMechanicalArm arm, List<ISolution> solutions)
    {
        Arm = arm;
        Solutions = solutions;
    }

    public void Reset()
    {
        if (Arm.CheckIsFacingRight())
        {
            Arm.ChangeDirection();
        }

        Arm.MoveForward(Arm.GetCurrentIndex());
        Arm.ChangeDirection();
    }

    public int MostAcidic()
    {
        var indexMin = 0;
        for (var i = 0; i < Solutions.Count; i++)
        {
            if (Solutions[indexMin].GetPH() > Solutions[i].GetPH())
            {
                indexMin = i;
            }
        }

        if (Solutions[indexMin].GetPH() > 7)
        {
            Reset();
            return -1;
        }

        var currentIndex = Arm.GetCurrentIndex();
        if (indexMin == currentIndex)
        {
            if (!Arm.CheckIsFacingRight())
            {
                Arm.ChangeDirection();
            }
        }
        else if (indexMin < currentIndex)
        {
            if (Arm.CheckIsFacingRight())
            {
                Arm.ChangeDirection();
            }

            Arm.MoveForward(currentIndex - indexMin);
            Arm.ChangeDirection();
        }
        else
        {
            if (!Arm.CheckIsFacingRight())
            {
                Arm.ChangeDirection();
            }

            Arm.MoveForward(indexMin - currentIndex);
        }

        return indexMin;
    }

    public override string ToString()
    {
        return $"Faceright: {Arm.CheckIsFacingRight()}\nIndex:{Arm.GetCurrentIndex()}\n{string.Join(", ", Solutions)}";
    }
}