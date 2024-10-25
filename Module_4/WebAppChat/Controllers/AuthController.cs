using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebAppChat.Model;
using WebAppChat.Services;

namespace WebAppChat.Controllers;

public class AuthController : BaseController
{
     ChatHub _chatHub;

    public AuthController(ChatHub chatHub) => _chatHub = chatHub;

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(Login obj)
    {
        var member = Provider.Member.Login(obj);
        if (member is null)
            return View(obj);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, member.MemberId),
            new Claim(ClaimTypes.Name, member.GivenName),
            new Claim(ClaimTypes.Email, member.Email),
            new Claim(ClaimTypes.Role, member.Role)
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(new ClaimsPrincipal(identity),
            new AuthenticationProperties { IsPersistent = obj.Remember });

        await _chatHub.LoginSuccessAsync(member);
        return Redirect("/");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/auth/login");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Member obj)
    {
        obj.MemberId = Guid.NewGuid().ToString().Replace("-", string.Empty);
        obj.Role = "Member";
        obj.Password = Helper.HashString(obj.Password);
        Provider.Member.Register(obj);
        return Redirect("/auth/login");
    }
}