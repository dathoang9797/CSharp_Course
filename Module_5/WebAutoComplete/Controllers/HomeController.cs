using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAutoComplete.Models;

namespace WebAutoComplete.Controllers;

public class HomeController : Controller
{
    private StoreContext Context { get; set; }

    private readonly ILogger<HomeController> _logger;

    public HomeController(
        ILogger<HomeController> logger,
        StoreContext storeContext
    )
    {
        _logger = logger;
        Context = storeContext;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Multiple()
    {
        return View();
    }

    public IActionResult LoadData(string q)
    {
        return Json(Context.Categories.Where(p => p.Name != null && p.Name.Contains(q)).Select(p => new
        {
            Label = p.Name,
            Value = p.Name,
            Id = p.Id
        }));
    }
}