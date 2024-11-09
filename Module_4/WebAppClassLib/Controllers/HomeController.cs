using System.Data.SqlClient;
using System.Diagnostics;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppClassLib.Models;

namespace WebAppClassLib.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}