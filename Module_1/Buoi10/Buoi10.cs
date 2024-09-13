using Buoi9.BaitapPH;

namespace Module_1.Buoi10;

public class Buoi10
{
    public Buoi10()
    {
        //value: int, float ,char ,struct => value
//reference => class, array

// void DoSomeThing(PhanSo p)
// {
//     p.Tu = 99;
//     p.Mau = 88;
//     Console.WriteLine("Ben trong ham");
//     Console.WriteLine(p);
// }
//
// void DoThat(Diem d)
// {
//     d.X = 9;
//     d.Y = 88;
//     Console.WriteLine("Ben trong ham");
//     Console.WriteLine(d);
// }
//
// var p1 = new PhanSo(3, 7);
// DoSomeThing(p1);
// Console.WriteLine(p1);
//
// var d1 = new Diem(8, 3);
// Console.WriteLine(d1);
// DoThat(d1);
// Console.WriteLine(d1);

// var p1 = new PhanSo(3, 7);
// var p2 = p1;
// p2.Tu = 33;
//
// Console.WriteLine(p1);
// Console.WriteLine(p2);
//
// //Reference
// Diem d1 = new Diem(3, 7);
// Diem d2 = d1;
// d2.X = 88;
//
// Console.WriteLine(d1);
// Console.WriteLine(d2);

//=================Bai Tap OOP Market================

// using Buoi10.Baitap_OOP_Market;
//
// Subject[] subjects =
// {
//     new Food(1, 10, 170_000_000, 250_000, 7_000_000)
// };
//
// var total = subjects.Sum(item => item.TienThue());
// Console.WriteLine($"Tong so tien thue la: {total}");
//=================Bai Tap OOP Market================

//=================Bai Tap OOP Market================

//=================Bai Tap PH===============

        var arm = new MechanicalArm(4, false);
        var listSolution = new List<ISolution>()
        {
            new Solution(7),
            new Solution(4),
            new Solution(10),
            new Solution(5),
            new Solution(6),
            new Solution(13),
        };

        var experiment = new Experiment(arm, listSolution);
        experiment.Reset();
        Console.WriteLine(experiment);
//=================Bai Tap PH================
    }
}