using DAL;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAdd()
    {
        var calculator = new Calculator();
        // Assert.AreEqual(20, calculator.Add(2, 7, 11));
        // 2 phương thức này giống nhau rider dề nghị dùng method dưới
        Assert.That(calculator.Add(2, 7, 11), Is.EqualTo(20));
    }
}