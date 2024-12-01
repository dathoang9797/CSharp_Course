using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class MemberController : BaseController
{
    public async Task<IActionResult> Index()
    {
        return View(await Provider.Member.GetMembers());
    }

    public async Task<IActionResult> Roles(string id)
    {
        return View(await Provider.Role.GetRolesChecked(id));
    }

    [HttpPost]
    public async Task<IActionResult> Roles(MemberInRole obj)
    {
        return Json(await Provider.MemberInRole.AddAsync(obj));
    }
}