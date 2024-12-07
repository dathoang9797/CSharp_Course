using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controller;

[Area("dashboard")]
public class HomeController : BaseController
{
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var token = User.FindFirstValue(ClaimTypes.Authentication);
        if (!string.IsNullOrWhiteSpace(token))
        {
            ViewBag.Accesses = await Provider.Access.GetAccesses(token) ?? Array.Empty<Access>();
        }

        return View();
    }
}