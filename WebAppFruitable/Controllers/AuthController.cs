using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using WebAppFruitable.Model;
using WebAppFruitable.Services;
using WebAppFruitables;
using WebAppFruitables.Services;

namespace WebAppFruitable.Controllers;

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

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(new ClaimsPrincipal(identity), new AuthenticationProperties()
        {
            IsPersistent = false
        });
        return Redirect("/home");
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

    public IActionResult GoogleSignIn()
    {
        var properties = new AuthenticationProperties()
        {
            RedirectUri = "/auth/googleresponse"
        };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    public async Task<IActionResult> GoogleResponse()
    {
        var member = new Member();
        var results = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (results.Principal != null)
        {
            foreach (var item in results.Principal.Claims)
            {
                switch (item.Type)
                {
                    // case ClaimTypes.Name:
                    //     member. = item.Value;
                    //     break;
                    case ClaimTypes.GivenName:
                        member.GivenName = item.Value;
                        break;
                    case ClaimTypes.Surname:
                        member.SurName = item.Value;
                        break;
                    case ClaimTypes.Email:
                        member.Email = item.Value;
                        break;
                    case ClaimTypes.NameIdentifier:
                        member.MemberId = item.Value;
                        break;
                }
            }

            var entity = new MemberEntity()
            {
                MemberId = Guid.NewGuid().ToString().Replace("-", string.Empty),
                Email = member.Email,
                Password = Helper.HashPassword(member.Password),
                Surname = member.SurName ?? string.Empty,
                GivenName = member.GivenName
            };

            var ret = Provider.Member.Add(entity);
            if (ret > 0)
                return Redirect("/auth");
        }

        return Json(member);
    }
}