using System.Data.SqlClient;
using System.Diagnostics;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppClassLib.Models;

namespace WebAppClassLib.Controllers;

public class HomeController : BaseController
{
    private ILogger<HomeController>? Logger { get; set; }

    public HomeController(ILogger<HomeController>? logger, IConfiguration configuration) : base(configuration)
    {
        Logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Manufacturers = Provider.Manufacturer.GetManufacturers();
        ViewBag.Categories = SiteProvider.Category.GetCategories();

        //Dùng internal sẽ không gọi được code dưới
        // var repository = new CategoryRepository(new SqlConnection());
        // ViewBag.Categories = repository.GetCategories();
        return View();
    }

    public IActionResult IndexTest()
    {
        ViewBag.Categories = SiteProviderTest.Category.GetCategories();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Category(int id)
    {
        var obj = SiteProvider.Category.GetCategory(id);
        if (obj != null)
            return View(obj);

        if (Logger != null)
            Logger.LogInformation($"Not found {id}");

        return Redirect("/");
    }

    public IActionResult CategoryTest(int id)
    {
        var obj = SiteProviderTest.Category.GetCategory(id);
        if (obj != null)
            return View(obj);

        if (Logger != null)
            Logger.LogInformation($"Not found {id}");
        return Redirect("/");
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Category obj)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var ret = SiteProvider.Category.Add(obj);
                if (ret > 0)
                {
                    Logger?.LogInformation($"Insert Category {obj.CategoryName} Success");
                }
            }
            catch (Exception e)
            {
                Logger?.LogInformation($"Insert Category {obj.CategoryName} Failed");
                return View(obj);
            }
        }

        return Redirect("/");
    }
}