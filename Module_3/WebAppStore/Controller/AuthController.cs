using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using WebAppStore.Model;
using WebAppStore.Services;
using WebAppVNPayment.Repository;

namespace WebAppStore;

public class AuthController : Controller
{
    private IEmailSender Sender { get; set; }
    private UserRepository UserRepository { get; set; }
    private SignInManager<IdentityUser> SignInManager { get; set; }

    public AuthController(UserManager<IdentityUser> manager, SignInManager<IdentityUser> signInManager,
        IEmailSender sender)
    {
        UserRepository = new UserRepository(manager);
        SignInManager = signInManager;
        Sender = sender;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await SignInManager.SignOutAsync();
        return Redirect("/auth/login");
    }

    [Authorize]
    public async Task<IActionResult> Change()
    {
        return View();
    }

    [Authorize, HttpPost]
    public async Task<IActionResult> Change(ChangeModel obj)
    {
        ModelState.Remove(nameof(obj.UserId));
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (ModelState.IsValid && !string.IsNullOrWhiteSpace(userId))
        {
            obj.UserId = userId;
            var result = await UserRepository.Change(obj);
            if (result != null)
            {
                if (result.Succeeded)
                {
                    return await Logout();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }

            ModelState.AddModelError("Error", "Not found user");
        }

        return View(obj);
    }

    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel obj)
    {
        var (user, status) = await UserRepository.Login(obj);
        if (status > 0 && user != null)
        {
            await SignInManager.SignInAsync(user, obj.Remember);
            return Redirect("/auth");
        }

        string[] arr = { "Username not found", "Password Failed" };
        ModelState.AddModelError("Error", arr[status + 1]);
        return View(obj);
    }

    public IActionResult Register() => View();

    public IActionResult Success() => View();

    public async Task<IActionResult> ConfirmEmail(string id, string token)
    {
        var result = await UserRepository.ConfirmEmail(id, WebUtility.UrlDecode(token));
        if (result != null)
        {
            if (result.Succeeded)
            {
                return Redirect("/auth/login");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
        }
        else
        {
            ModelState.AddModelError("Error", $"Not found ID: {id}");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel obj)
    {
        ModelState.Remove(nameof(obj.Id));
        obj.Id = Guid.NewGuid().ToString().Replace("-", "");
        if (ModelState.IsValid)
        {
            var result = await UserRepository.Add(obj);
            if (result.Succeeded)
            {
                var token = await UserRepository.GenerateEmailConfirmToken(obj.Id);
                if (string.IsNullOrWhiteSpace(token))
                {
                    ModelState.AddModelError("Error", "Not found token");
                }
                else
                {
                    var url = Url.Action("confirmemail", "auth",
                        new { token = WebUtility.UrlEncode(token), id = obj.Id },
                        protocol: Request.Scheme);
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        ModelState.AddModelError("Error", "Url Null");
                    }
                    else
                    {
                        if (obj.Email != null)
                        {
                            await Sender.SendEmailAsync(obj.Email, "Confirm Email",
                                $"<a href=\"{url}\">Please click link to active your Email</a>");
                            TempData["Msg"] =
                                $"Register Success, Please check your email: {obj.Email} for active email";
                            return Redirect("/auth/success");
                        }
                    }
                }

                return Redirect("/auth/login");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
        }

        return View(obj);
    }
}