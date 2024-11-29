using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

public class AuthController : BaseController
{
    [Authorize]
    public async Task<IActionResult> Index()
    {
        try
        {
            var token = User.FindFirstValue(ClaimTypes.Authentication);
            if (string.IsNullOrWhiteSpace(token))
                return Redirect("/auth/login");

            var member = await Provider.Member.GetMember(token);
            return View(member);
        }
        catch (Exception e)
        {
            return await RefreshToken("/auth");
        }
    }

    public async Task<IActionResult> Register()
    {
        var result = await Provider.Category.GetCategories();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(Member obj)
    {
        obj.CreatedDate = DateTime.UtcNow;
        obj.UpdatedDate = DateTime.UtcNow;
        var ret = await Provider.Member.AddAsync(obj);
        if (ret > 0)
        {
            return Redirect("/auth/login");
        }

        return View(obj);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var token = await Provider.Member.Login(model);
        if (string.IsNullOrWhiteSpace(token))
        {
            ModelState.AddModelError("Error", "Login Failed");
            return View(model);
        }

        var securityHandle = new JwtSecurityTokenHandler();
        var securityToken = securityHandle.ReadJwtToken(token);
        var claims = new List<Claim>(securityToken.Claims)
        {
            new(ClaimTypes.Authentication, token)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(new ClaimsPrincipal(identity), new AuthenticationProperties()
        {
            IsPersistent = false
        });
        await Helper.SignIn(HttpContext, token);
        return Redirect("/auth");
    }

    [Authorize]
    public async Task<IActionResult> RefreshToken(string returnUrl = "/")
    {
        var token = User.FindFirstValue(ClaimTypes.Authentication);
        if (string.IsNullOrWhiteSpace(token))
        {
            return Redirect("/auth/login");
        }

        var tokenUpdate = await Provider.Member.RefreshToken(token);
        if (string.IsNullOrWhiteSpace(tokenUpdate))
            return Redirect("/auth/login");

        await Helper.SignIn(HttpContext, tokenUpdate);
        return Redirect(returnUrl);
    }
}