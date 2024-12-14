using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
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
        // //ViewData
        // //ViewBag
        // ViewData["Title"] = "Web App Store";
        // ViewData["Description"] = "Description for web app Store";
        // ViewData["a"] = 7;
        // ViewData["b"] = 9;
        //
        //
        // ViewBag.Departments = _list;
        // ViewBag.Total = _list.Count;
        // var departments = new DepartmentTotal
        // {
        //     Departments = _list,
        //     Total = _list.Count
        // };
        // return View(departments);
        
        var taxiTripSample = new TaxiTrip()
        {
            VendorId = "VTS",
            RateCode = "1",
            PassengerCount = 1,
            TripTime = 1140,
            TripDistance = 3.75f,
            PaymentType = "CRD",
            FareAmount = 0 // To predict. Actual/Observed = 15.5
        };
        
        
        return View(taxiTripSample);
    }

    [HttpPost]
    public IActionResult Index(TaxiTrip obj)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "data", "Model.zip");
        var mlContext = new MLContext();
        var model = mlContext.Model.Load(path, out DataViewSchema dataView);

        var predictionFunction = mlContext.Model
            .CreatePredictionEngine<TaxiTrip, TaxiTripFarePrediction>(model);
        var prediction = predictionFunction.Predict(new TaxiTrip
        {
            VendorId = obj.VendorId,
            RateCode = obj.RateCode,
            PassengerCount = obj.PassengerCount,
            TripTime = obj.TripTime,
            TripDistance = obj.TripDistance,
            PaymentType = obj.PaymentType
        });

        ViewBag.Result = prediction.FareAmount;
        return View(obj);
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