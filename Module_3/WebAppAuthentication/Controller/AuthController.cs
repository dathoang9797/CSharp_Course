using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppAuthentication.Model;
using WebAppAuthentication.Repository;

namespace WebAppAuthentication;

public class AuthController : Controller
{
    private MemberRepository? _MemberRepository { get; set; }

    private MemberRepository Repository =>
        _MemberRepository ??= HttpContext.RequestServices.GetRequiredService<MemberRepository>();

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
                    case ClaimTypes.Name:
                        member.Name = item.Value;
                        break;
                    case ClaimTypes.GivenName:
                        member.GivenName = item.Value;
                        break;
                    case ClaimTypes.Surname:
                        member.Surname = item.Value;
                        break;
                    case ClaimTypes.Email:
                        member.Email = item.Value;
                        break;
                    case ClaimTypes.NameIdentifier:
                        member.MemberId = item.Value;
                        break;
                }
            }

            var ret = Repository.Add(member);
            if (ret > 0)
                return Redirect("/auth");
        }

        return Json(member);
    }

    [Authorize]
    public IActionResult Index() => View();
}