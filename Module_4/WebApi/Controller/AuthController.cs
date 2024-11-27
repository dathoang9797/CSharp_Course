using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controller;

[ApiController]
[Route("api/member")]
public class AuthController : BaseController
{
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
    public Member? Login(LoginModel obj)
    {
        var rsp = Provider.Member.Login(obj);
        return rsp;
    }
}