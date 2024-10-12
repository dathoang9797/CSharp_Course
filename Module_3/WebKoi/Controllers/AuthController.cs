using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using WebKoi.Model;

namespace WebKoi;

public class AuthController : BaseController
{
    public AuthController(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Register obj)
    {
        if (ModelState.IsValid)
        {
            var ret = Provider.Member.Add(obj);
            if (ret > 0)
            {
                return Redirect("/auth/login");
            }

            ModelState.AddModelError("Error", "Register Failed");
        }

        return View(obj);
    }

    public IActionResult Login(string? returnUrl)
    {
        return View();
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/auth/login");
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel obj, string? returnUrl)
    {
        var member = Provider.Member.GetMember(obj);
        if (member == null)
        {
            ModelState.AddModelError("Error", "Login failed");
            return View(obj);
        }

        var list = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, member.MemberId ?? string.Empty),
            new Claim(ClaimTypes.Name, member.Name ?? string.Empty),
            new Claim(ClaimTypes.Email, member.Email ?? string.Empty),
            new Claim(ClaimTypes.GivenName, member.GivenName ?? string.Empty),
            new Claim(ClaimTypes.Surname, member.Surname ?? string.Empty),
        };
        var properties = new AuthenticationProperties()
        {
            IsPersistent = obj.R
        };
        var principal =
            new ClaimsPrincipal(new ClaimsIdentity(list, CookieAuthenticationDefaults.AuthenticationScheme));
        await HttpContext.SignInAsync(principal, properties);
        if (string.IsNullOrWhiteSpace(returnUrl))
            return Redirect("/");

        return Redirect(returnUrl);
    }

    public IActionResult GoogleLogin(string? returnUrl)
    {
        var url = Url.Action("googleresponse", "auth", new { returnUrl }, protocol: Request.Scheme);
        var properties = new AuthenticationProperties()
        {
            RedirectUri = url
        };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    public async Task<IActionResult> GoogleResponse(string? returnUrl)
    {
        await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (string.IsNullOrEmpty(returnUrl))
            return Redirect("/");

        return Redirect(returnUrl);
    }
}