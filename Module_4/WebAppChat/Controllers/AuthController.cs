using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebAppChat.Model;

namespace WebAppChat.Controllers;

public class AuthController : BaseController
{
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
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(new ClaimsPrincipal(identity),
            new AuthenticationProperties { IsPersistent = obj.Remember });
        return Redirect("/");
    }
}