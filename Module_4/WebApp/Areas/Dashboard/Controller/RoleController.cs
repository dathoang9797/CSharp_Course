using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controller;

[Area("dashboard")]
public class RoleController : BaseController
{
    [Authorize]
    public async Task<IActionResult> Index()
    {
        return View(await Provider.Role.GetRolesAsync());
    }

    public async Task<IActionResult> Accesses(int id)
    {
        ViewBag.AccessChecked = await Provider.Access.GetAccessesCheckedByRole(id) ?? Array.Empty<AccessChecked>();
        return View(await Provider.Role.GetRoleAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Accesses(AccessRole obj)
    {
        return Json(await Provider.AccessRole.SaveAsync(obj));
    }
}