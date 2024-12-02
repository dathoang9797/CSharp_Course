using Microsoft.AspNetCore.Mvc;

namespace WebAppFruitables.Areas.Dashboard.Controller;

[Area("dashboard")]
public class HomeController : Microsoft.AspNetCore.Mvc.Controller
{
    public IActionResult Index()
    {
        return View();
    }
}