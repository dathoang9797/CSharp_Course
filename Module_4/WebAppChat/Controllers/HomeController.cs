using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppChat.Controllers;

public class HomeController : BaseController
{

    public HomeController()
    {
    }

    [Authorize]
    public IActionResult Index()
    {
        if (User.IsInRole("Member"))
        {
            return View(Provider.Member.GetEmployees());
        }
        return View(Provider.Member.GetMembers());
    }
}