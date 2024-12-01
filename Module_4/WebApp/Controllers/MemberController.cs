using Microsoft.AspNetCore.Mvc;

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
}