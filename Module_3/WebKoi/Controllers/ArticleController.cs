using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebKoi.Model;

namespace WebKoi;

[Authorize]
public class ArticleController : BaseController
{
    public ArticleController(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Add()
    {
        Console.WriteLine(User.Identity?.Name);
        Console.WriteLine(User.FindFirstValue((ClaimTypes.NameIdentifier)));
        return View();
    }
}