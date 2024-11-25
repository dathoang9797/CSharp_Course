using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly List<Department> _list =
    [
        new Department { Id = 1, Name = "A", Description = "Description A" },
        new Department { Id = 2, Name = "B", Description = "Description B" },
        new Department { Id = 3, Name = "C", Description = "Description C" }
    ];

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //ViewData
        //ViewBag
        ViewData["Title"] = "Web App Store";
        ViewData["Description"] = "Description for web app Store";
        ViewData["a"] = 7;
        ViewData["b"] = 9;


        ViewBag.Departments = _list;
        ViewBag.Total = _list.Count;
        var departments = new DepartmentTotal
        {
            Departments = _list,
            Total = _list.Count
        };
        return View(departments);
    }

    public IActionResult DeleteAll(int[] ids)
    {
        return View(ids);
    }
    
    [HttpPost]
    public IActionResult AddAll(List<Department> list)
    {
        return View(list);
    }

    public IActionResult Dynamic()
    {
        return View(new { Departments = _list, Total = _list.Count });
    }

    public IActionResult JsonData()
    {
        return Json(new { Departments = _list, Total = _list.Count });
    }
}