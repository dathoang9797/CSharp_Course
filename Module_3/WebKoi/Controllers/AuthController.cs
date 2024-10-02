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