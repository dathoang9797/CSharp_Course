using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppFruitable.Controllers;
using WebAppFruitable.Model;

namespace WebAppFruitable.Areas.Dashboard.Controller;

[Area("dashboard")]
public class RoleController : BaseController
{
    [Authorize]
    public IActionResult Index()
    {
        var listRole = Provider.Role.GetRoles();
        return View(listRole);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Add(Role obj)
    {
        var ret = Provider.Role.Add(obj);
        return ret > -1 ? Redirect("/dashboard/role") : Redirect("/dashboard/err");
    }

    [Authorize]
    [HttpPost]
    [Route("/dashboard/role/delete/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        //id 1 is Admin
        if (id == 1)
        {
            TempData["Msg"] = "Can't delete admin";
            return Redirect("/dashboard/role");
        }

        var ret = Provider.Role.Delete(id);
        return ret > -1 ? Redirect("/dashboard/role") : Redirect("/dashboard/err");
    }
}