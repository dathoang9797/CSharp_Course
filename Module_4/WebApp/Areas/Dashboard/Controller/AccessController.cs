using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Areas.Dashboard.Controller;

[Area("dashboard")]
public class AccessController : BaseController
{
    [Authorize]
    public async Task<IActionResult> Index()
    {
        try
        {
            var token = User.FindFirstValue(ClaimTypes.Authentication);
            if (!string.IsNullOrWhiteSpace(token))
            {
                var listAccess = await Provider.Access.GetAccesses(token);
                if (listAccess != null)
                {
                    // var parents = await Provider.Access.GetParents(token);
                    // if (parents != null)
                    //     ViewBag.Parents = new SelectList(parents);

                    var listSelectItems = new List<SelectListItem>();
                    foreach (var item in listAccess)
                    {
                        var group = new SelectListGroup { Name = item.AccessName };
                        if (item.Children != null)
                        {
                            foreach (var child in item.Children)
                            {
                                var selectItem = new SelectListItem()
                                {
                                    Text = child.AccessName,
                                    Value = child.AccessId.ToString(),
                                    Group = group
                                };
                                listSelectItems.Add(selectItem);
                            }
                        }

                        if (listSelectItems.Any())
                        {
                            ViewBag.Parents = listSelectItems;
                        }
                    }

                    return View(listAccess);
                }
            }

            return View();
        }
        catch (Exception e)
        {
            return Redirect("/auth/login");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(Access obj)
    {
        var ret = await Provider.Access.AddAsync(obj);
        if (ret > 0)
        {
            return Redirect("/dashboard/access");
        }

        return Redirect("/dashboard/access/error");
    }
}