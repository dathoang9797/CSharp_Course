using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
}