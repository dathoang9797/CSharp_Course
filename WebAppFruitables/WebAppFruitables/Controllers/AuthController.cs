using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppFruitables.Model;
using WebAppFruitables.Services;

namespace WebAppFruitables.Controllers;

public class AuthController : BaseController
{
    private IConfiguration Configuration { get; set; }

    public AuthController(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(Member? obj)
    {
        if (obj == null)
            return View();

        var entity = new MemberEntity()
        {
            Email = obj.Email,
            Password = Helper.HashPassword(obj.Password),
        };

        var member = await Provider.Member.Login(entity);
        if (member == null)
            return View();

        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, member.MemberId),
            new(ClaimTypes.Email, member.Email),
            new(ClaimTypes.GivenName, member.GivenName)
        };

        var name = member.GivenName + " " + member.Surname;
        claims.Add(new Claim(ClaimTypes.Surname, member.Surname));
        claims.Add(new Claim(ClaimTypes.Name, name));

        var secretKey = Configuration["Jwt:SecretKey"] ?? string.Empty;
        if (string.IsNullOrWhiteSpace(secretKey))
            return View(obj);

        var token = Helper.GenerateToken(claims, secretKey);
        if (string.IsNullOrWhiteSpace(token))
        {
            ModelState.AddModelError("Error", "Login Failed");
            return View(obj);
        }

        claims.Add(new Claim(ClaimTypes.Authentication, token));
        await Helper.SignIn(HttpContext, claims);
        return Redirect("/auth");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Member? obj)
    {
        if (obj == null)
            return View(obj);

        var entity = new MemberEntity()
        {
            MemberId = Guid.NewGuid().ToString().Replace("-", string.Empty),
            Email = obj.Email,
            Password = Helper.HashPassword(obj.Password),
            Surname = obj.SurName ?? string.Empty,
            GivenName = obj.GivenName
        };

        var ret = Provider.Member.Add(entity);
        if (ret > 0)
        {
            return Redirect("/");
        }

        return View(obj);
    }
}