using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/")]
public class MemberController : BaseController
{
    [HttpGet("member")]
    public IEnumerable<Member> GetMembers()
    {
        return Provider.Member.GetMembers();
    }
}