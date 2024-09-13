namespace Buoi9.BaitapPH;

public interface IMechanicalArm
{
    //uint => unsign integer
    int GetCurrentIndex();
    bool CheckIsFacingRight();
    void ChangeDirection();
    void MoveForward(int numLocation);
}