using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controller;

[Area("dashboard")]
public class HomeController : BaseController
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Accesses = await Provider.Access.GetAccesses() ?? Array.Empty<Access>();
        return View();
    }
}