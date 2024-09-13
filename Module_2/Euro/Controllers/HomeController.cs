using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

namespace Euro.Controllers;

public class HomeController : BaseController
{
    // GET
    public IActionResult Index()
    {
        var listTeams = Provider.Team.GetTeams();
        ViewBag.Teams = listTeams.GroupBy(p => p.GroupName);
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
}