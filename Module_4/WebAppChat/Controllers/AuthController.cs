using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using WebAppChat.Model;
using WebAppChat.Services;
using CookieOptions = Microsoft.AspNetCore.Http.CookieOptions;

namespace WebAppChat.Controllers;

public class AuthController : BaseController
{
    ChatHub _chatHub;

    [HttpPost]
    public IActionResult ChangeLanguage(string cul)
    {
        Response.Cookies.Append
        (
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cul)),
            new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddMonths(1) }
        );
        return Json(cul);
    }

    
    public IActionResult CheckEmail(string email)
    {
        return Json(!email.Equals("dathoang9797@gmail.com"));
    }

    public AuthController(ChatHub chatHub) => _chatHub = chatHub;

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(Login obj)
    {
        if (ModelState.IsValid)
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

            await _chatHub.SuccessAsync("login", member);
            return Redirect("/");
        }

        return View(obj);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        if (string.IsNullOrEmpty(userId))
            return Redirect("/auth/login");

        var userEmail = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
        var ret = Provider.Member.Logout(userId);
        if (ret > 0)
        {
            var member = new Member()
            {
                MemberId = userId,
                IsOnline = false,
                Email = userEmail,
            };

            await _chatHub.SuccessAsync("logout", member);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        return Redirect("/auth/login");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(Member obj)
    {
        obj.MemberId = Guid.NewGuid().ToString().Replace("-", string.Empty);
        obj.Role = "Member";
        obj.Password = Helper.HashString(obj.Password);
        var ret = Provider.Member.Register(obj);
        if (ret > 0)
        {
            await _chatHub.SuccessAsync("register", obj);
        }

        return Redirect("/auth/login");
    }
}