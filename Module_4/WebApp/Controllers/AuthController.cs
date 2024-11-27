using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : BaseController
{
    public async Task<IActionResult> Register()
    {
        var result = await Provider.Category.GetCategories();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(Member obj)
    {
        obj.CreateDate = DateTime.UtcNow;
        obj.UpdateDate = DateTime.UtcNow;
        obj.CreateDate = DateTime.UtcNow;
        var ret = await Provider.Member.AddAsync(obj);
        if (ret > 0)
        {
            return Redirect("/auth/login");
        }

        return View(obj);
    }
}