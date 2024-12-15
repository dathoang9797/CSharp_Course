using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;
using WebAppFruitable.Services;
using WebAppFruitables;

namespace WebAppFruitable.Controllers;

public class AuthController : BaseController
{
    private IEmailSender Sender { get; set; }
    private IConfiguration Configuration { get; set; }

    public AuthController(
        IConfiguration configuration,
        IEmailSender sender
    )
    {
        Configuration = configuration;
        Sender = sender;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(MemberBody? obj)
    {
        if (obj == null)
            return View();

        var entity = new Member
        {
            Email = obj.Email,
            Password = Helper.HashPassword(obj.Password),
            LoginDate = DateTime.UtcNow
        };

        var member = await Provider.Member.Login(entity);
        if (member == null)
            return Redirect("/auth/register");

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
    public async Task<IActionResult> Register(MemberBody? obj)
    {
        try
        {
            if (obj == null)
                return View(obj);

            var entity = new Member()
            {
                MemberId = Guid.NewGuid().ToString().Replace("-", string.Empty),
                Email = obj.Email,
                Password = Helper.HashPassword(obj.Password),
                Surname = obj.SurName ?? string.Empty,
                GivenName = obj.GivenName,
                CreatedDate = DateTime.UtcNow
            };

            var ret = Provider.Member.Add(entity);
            if (ret > 0)
            {
                if (!string.IsNullOrWhiteSpace(entity.Email))
                {
                    var body = $"Welcome {entity.GivenName} {entity.Surname}";
                    await Sender.SendEmailAsync(entity.Email, "Register Success", body);
                }

                return Redirect("/auth/login");
            }

            return View(obj);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is SqlException sqlEx)
            {
                var errorCode = sqlEx.Number;
                if (errorCode == 2627)
                {
                    ViewData["ErrorMessage"] = "Email đã tồn tại";
                }
            }
            else
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return View(obj);
        }
    }

    [Authorize]
    public IActionResult ResetPassword()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ResetPassword(MemberBody? obj)
    {
        if (obj == null ||
            string.IsNullOrWhiteSpace(obj.Email) ||
            string.IsNullOrWhiteSpace(obj.Password)
           )
            return View(obj);

        var resetToken = await Provider.Member.RequestPasswordResetAsync(obj.Email);
        if (string.IsNullOrWhiteSpace(resetToken))
        {
            ViewData["ErrorMessage"] = "Member not found";
            return View(obj);
        }

        var ret = await Provider.Member.ResetPasswordAsync(obj.Email, resetToken, obj.Password);
        if (ret == -1)
        {
            return View(obj);
        }

        
        TempData["Msg"] = "Please Login with new Password";
        return await Logout();
    }

    public IActionResult ForgotPassword() => View();

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            ModelState.AddModelError("", "Email is required.");
            return View();
        }

        var member = await Provider.Member.GetMember(email);
        if (member == null)
        {
            TempData["Message"] = "Email not found";
            return Redirect("/auth/login");
        }

        var resetToken = await Provider.Member.ForgotPasswordAsync(member);
        if (string.IsNullOrWhiteSpace(resetToken))
        {
            TempData["Message"] = "Token Invalid";
            return View(member);
        }

        var resetUrl = Url.Action(
            "ResetForgotPassword",
            "Auth", new { token = resetToken },
            Request.Scheme);

        await Sender.SendEmailAsync(email, "Password Reset Request",
            $"Click the link to reset your password: <a href=\"{resetUrl}\">{resetUrl}</a>");

        TempData["Message"] = "A password reset link has been sent to your email.";
        return RedirectToAction("Login", "Auth");
    }

    public IActionResult ResetForgotPassword(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            TempData["Message"] = "Email not found";
            return Redirect("/auth/login");
        }

        return View(new ResetForgotPassword { Token = token });
    }
    
    [HttpPost]
    public async Task<IActionResult> ResetForgotPassword(ResetForgotPassword model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var ret = await Provider.Member.ResetForgotPasswordAsync(model);
        if (ret == null)
        {
            ModelState.AddModelError("", "Invalid or expired token.");
            return View(model);
        }

        if (ret == -1)
        {
            TempData["Message"] = "Update not succesed";
            return Redirect("/auth/login");
        }

        TempData["Message"] = "Your password has been reset successfully.";
        return Redirect("/auth/login");
    }
}