using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppChat.Services;

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

    [HttpPost, Authorize]
    public IActionResult Messages(string id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
            return Json(Provider.Message.GetMessages(userId, id));

        return Json(null);
    }

    [HttpPost]
    public  IActionResult Upload(IFormFile? f)
    {
        if (f != null)
        {
            var extension = Path.GetExtension(f.FileName);
            var fileName = Helper.RandomString(32 - extension.Length) + extension;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images",fileName);
            using (Stream stream = new FileStream(path,FileMode.Create))
            {
                f.CopyTo(stream);
            }
            return Json(fileName);
        }

        return Json(null);
    }
}