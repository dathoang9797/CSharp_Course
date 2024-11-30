using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController : BaseController
{
    private IConfiguration Configuration { get; set; }

    public AuthController(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    [Authorize]
    [HttpGet]
    public Member? Index()
    {
        var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (memberId == null)
            return null;

        return Provider.Member.GetMember(memberId);
    }

    [HttpPost]
    [Route("register")]
    public int Add(Member obj)
    {
        if (ModelState.IsValid)
        {
            return Provider.Member.Add(obj);
        }

        return -1;
    }

    //Trả về Jwt Token
    [HttpPost("login")]
    public string? Login(LoginModel obj)
    {
        var member = Provider.Member.Login(obj);
        if (member == null || member?.MemberId == null)
            return null;

        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, member.MemberId),
            new(ClaimTypes.Email, member.Email),
            new(ClaimTypes.GivenName, member.GivenName)
        };

        var name = member.GivenName;
        if (member.SurName != null)
        {
            name += " " + member.SurName;
            claims.Add(new Claim(ClaimTypes.Surname, member.SurName));
        }

        claims.Add(new Claim(ClaimTypes.Name, name));
        if (member.SurName != null)
        {
            claims.Add(new Claim(ClaimTypes.Surname, member.SurName));
        }

        var secretKey = Configuration["Jwt:SecretKey"] ?? string.Empty;
        if (string.IsNullOrWhiteSpace(secretKey))
            return null;

        return Helper.GenerateToken(claims, secretKey);
    }

    [HttpPost("refresh")]
    public string? RefreshToken(Token obj)
    {
        var secretKey = Configuration["Jwt:SecretKey"];
        if (string.IsNullOrWhiteSpace(secretKey))
            return null;
        return Helper.RefreshToken(obj.AccessToken, secretKey);
    }
}