using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebAppClassLib.Controllers;

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

    [Test]
    public void TestGetCategories()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("./appsettings.json").Build();
        using var provider = new SiteProvider(configuration);
        var list = provider.Category.GetCategories();
        var categories = list.ToList();
        Assert.That(categories, Is.InstanceOf<IEnumerable<Category>>());
        Assert.That(categories.Count != 0, Is.EqualTo(true));
    }

    [Test]
    public void TestHomeCategory()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("./appsettings.json").Build();
        var controller = new HomeController(null, configuration);
        var result = controller.CategoryTest(1) as ViewResult;
        if (result == null)
        {
            Assert.Fail();
            return;
        }

        Assert.That(result.Model, Is.InstanceOf<Category>());
    }

    [Test]
    public void TestHomeCategoryNotFound()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("./appsettings.json").Build();
        var controller = new HomeController(null, configuration);
        var result = controller.CategoryTest(-1) as RedirectResult;
        if (result == null)
        {
            Assert.Fail();
            return;
        }

        Assert.That(result.Url, Is.EqualTo("/"));
    }

    [Test]
    public void TestHome()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("./appsettings.json").Build();
        var controller = new HomeController(null, configuration);
        var result = controller.IndexTest() as ViewResult;
        if (result == null)
        {
            Assert.Fail();
            return;
        }

        Assert.That(result.ViewData["Categories"], Is.InstanceOf<List<Category>>());
        // Assert.That(result.ViewData["CategoSries"], Is.InstanceOf<List<Category>>());
    }
}