namespace Buoi9.Interface;

//Không thể khởi tạo
//Không có khái niệm field
//Không có constructor vì không có field
public interface IAnimal
{
    void Go(); //default public

    //Không có tính kế thừa
    public void Eat()
    {
        Console.WriteLine("Cat eat");
    }
}