using Microsoft.AspNetCore.Mvc;


namespace WebAppStore.Areas.Dashboard;

[Area("dashboard")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}