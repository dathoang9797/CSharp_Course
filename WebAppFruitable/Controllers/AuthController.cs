using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using WebAppFruitables.Model;
using WebAppFruitables.Services;

namespace WebAppFruitables.Controllers;

public class AuthController : BaseController
{
    private IEmailSender Sender { get; set; }
    private IConfiguration Configuration { get; set; }

    public AuthController(IConfiguration configuration, IEmailSender sender)
    {
        Configuration = configuration;
        Sender = sender;
    }

    [Authorize]
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
            new(ClaimTypes.GivenName, member.GivenName),
            new(ClaimTypes.Surname, member.Surname),
        };

        var name = member.GivenName + " " + member.Surname;
        claims.Add(new Claim(ClaimTypes.Surname, member.Surname));
        claims.Add(new Claim(ClaimTypes.Name, name));

        // var secretKey = Configuration["Jwt:SecretKey"] ?? string.Empty;
        // var token = Helper.GenerateToken(claims, secretKey);
        // claims.Add(new Claim(ClaimTypes.Authentication, token));

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(new ClaimsPrincipal(identity), new AuthenticationProperties()
        {
            IsPersistent = false
        });
        return Redirect("/auth");
    }

    [Authorize]
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
    public async Task<IActionResult> Register(Member? obj)
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
            if (!string.IsNullOrWhiteSpace(entity.Email))
            {
                var body = $"Welcome {entity.GivenName} {entity.Surname}";
                await Sender.SendEmailAsync(entity.Email, "Register Success", body);
                TempData["Msg"] = $"Login Success Please check your email: {entity.Email}";
            }

            return Redirect("/");
        }

        return View(obj);
    }
}