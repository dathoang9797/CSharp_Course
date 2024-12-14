using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using WebAppStore.Model;
using WebAppStore.Repository;

namespace WebAppStore;

public class AuthController : Controller
{
    private IEmailSender _Sender { get; set; }
    private UserRepository _UserRepository { get; set; }
    private SignInManager<IdentityUser> _SignInManager { get; set; }

    public AuthController(
        UserManager<IdentityUser> manager,
        SignInManager<IdentityUser> signInManager,
        IEmailSender sender
    )
    {
        _UserRepository = new UserRepository(manager);
        _SignInManager = signInManager;
        _Sender = sender;
    }

    public IActionResult ResetPassword() => View();

    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPassword obj)
    {
        var result = await _UserRepository.ResetPassword(obj);
        if (result != null)
        {
            if (result.Succeeded)
            {
                TempData["Msg"] = "Please Login with new Password";
                return Redirect("/auth/login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
        }
        else
        {
            ModelState.AddModelError("Error", "Your token invalid");
        }

        return View();
    }

    public IActionResult Forgot() => View();

    [HttpPost]
    public async Task<IActionResult> Forgot(string email)
    {
        var obj = await _UserRepository.GeneratePasswordResetToken(email);
        if (obj != null)
        {
            var url = Url.Action("resetpassword", "auth", new { id = obj.Id, token = obj.Token },
                protocol: Request.Scheme);
            if (!string.IsNullOrEmpty(url))
            {
                var body = $"<a href=\"{url}\">Click here to Reset your password</a>";
                await _Sender.SendEmailAsync(email, "Web Store Reset Password", body);
                TempData["Msg"] = $"Please check your email: {email} to reset your password";
                return Redirect("/auth/success");
            }
        }

        ModelState.AddModelError("Error", "Email Invalid");
        return View();
    }

    public IActionResult GoogleSignIn()
    {
        // "https://localhost:7235/auth/googleresponse";
        var url = Url.Action("googleresponse", "auth", null, protocol: Request.Scheme);
        if (string.IsNullOrWhiteSpace(url))
            return Redirect("/auth/error");

        var properties = _SignInManager.ConfigureExternalAuthenticationProperties(
            GoogleDefaults.AuthenticationScheme, url
        );
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    public async Task<IActionResult> GoogleResponse()
    {
        var user = new IdentityUser();
        // _SignInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
        var results = await _SignInManager.GetExternalLoginInfoAsync();
        if (results != null)
        {
            foreach (var item in results.Principal.Claims)
            {
                switch (item.Type)
                {
                    case ClaimTypes.NameIdentifier:
                        user.Id = item.Value;
                        break;
                    case ClaimTypes.Email:
                        user.Email = item.Value;
                        break;
                    case ClaimTypes.Name:
                        user.UserName = item.Value;
                        break;
                }
            }

            user.UserName = user.Email;
            var result = await _UserRepository.Add(user);
            if (result != null)
            {
                await _SignInManager.SignInAsync(user, new AuthenticationProperties { IsPersistent = true },
                    CookieAuthenticationDefaults.AuthenticationScheme);
                return Redirect("/auth");
            }

            TempData["Msg"] = "Failed";
            return Redirect("/auth/error");
        }

        return Json(user);
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
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
            var result = await _UserRepository.Change(obj);
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
        var (user, status) = await _UserRepository.Login(obj);
        if (status > 0 && user != null)
        {
            var isUseTwoFactor = true;
            if (isUseTwoFactor)
            {
                var token = await _UserRepository.GenerateTwoFactorTokenAsync(user, "Email");
                if (token != null)
                {
                    // var url = Url.Action("confirmtwofactor", "auth", new { id = user.Id },
                    //     protocol: Request.Scheme);
                    // if (!string.IsNullOrEmpty(url))
                    // {
                    var body = $"Your OPT IS:{token}";
                    if (user.Email != null)
                    {
                        await _Sender.SendEmailAsync(user.Email, "Confirm Email to login", body);
                        TempData["Msg"] = $"Login Success Please check your email: {user.Email}";
                        return Redirect($"/auth/confirmtwofactor/{user.Id}");
                    }
                    // }
                    // else
                    // {
                    //     ModelState.AddModelError("Error", "Url Invalid");
                    // }
                }
                else
                {
                    ModelState.AddModelError("Error", "Token Invalid");
                }
            }
            else
            {
                await _SignInManager.SignInAsync(user, obj.Remember);
                return Redirect("/auth");
            }

            ModelState.AddModelError("Error", "Login Failed");
            return View(obj);
        }

        string[] arr = { "Username not found", "Password Failed" };
        ModelState.AddModelError("Error", arr[status + 1]);
        return View(obj);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _SignInManager.SignOutAsync();
        return Redirect("/auth/login");
    }

    public IActionResult ConfirmTwoFactor(string id)
    {
        return View();
    }

    public IActionResult Register() => View();

    public IActionResult Success() => View();

    public async Task<IActionResult> ConfirmEmail(string id, string token)
    {
        var result = await _UserRepository.ConfirmEmail(id, WebUtility.UrlDecode(token));
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
            var result = await _UserRepository.Add(obj);
            if (result.Succeeded)
            {
                var token = await _UserRepository.GenerateEmailConfirmToken(obj.Id);
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
                            await _Sender.SendEmailAsync(obj.Email, "Confirm Email",
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