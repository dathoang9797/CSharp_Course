using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebAppFruitable.Controllers;
using WebAppFruitables;

namespace WebAppFruitable.Areas.Dashboard.Controller;

[Area("dashboard")]
public class MemberController : BaseController
{
    [Authorize]
    public IActionResult Index()
    {
        var listMember = Provider.Member.GetMembers();
        return View(listMember);
    }

    [Authorize]
    [Route("/dashboard/member/roles/{memberId}")]
    public IActionResult Roles([FromRoute] string memberId)
    {
        if (string.IsNullOrWhiteSpace(memberId))
            return Redirect("/dashboard/member");

        var listRolesByMember = Provider.Role.GetRolesByMember(memberId);
        return View(listRolesByMember);
    }

    [Authorize]
    [HttpPost]
    [Route("/dashboard/member/roles")]
    public IActionResult SaveMemberInRole(MemberInRole obj)
    {
        return Json(Provider.MemberInRole.AddAsync(obj));
    }
}