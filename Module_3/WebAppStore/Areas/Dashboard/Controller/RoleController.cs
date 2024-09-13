using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppVNPayment.Repository;

namespace WebAppStore.Areas.Dashboard;

[Area("dashboard")]
public class RoleController : Controller
{
    private RoleRepository RoleRepository { get; set; }

    public RoleController(RoleRepository roleRepository)
    {
        RoleRepository = roleRepository;
    }

    public IActionResult Index()
    {
        return View(RoleRepository.GetRoles());
    }

    public IActionResult Add() => View();

    [HttpPost]
    public async Task<IActionResult> Add(IdentityRole obj)
    {
        var result = await RoleRepository.Add(obj);
        if (result != null && result.Succeeded)
            return Redirect("/dashboard/role");

        return Redirect("/dashboard/role/error");
    }

    public async Task<IActionResult> Delete(string id)
    {
        var result = await RoleRepository.Delete(id);
        if (result != null && result.Succeeded)
            return Redirect("/dashboard/role");

        return Redirect("/dashboard/role/error");
    }
}