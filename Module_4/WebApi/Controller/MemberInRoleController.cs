using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class MemberInRoleController : BaseController
{
    [HttpPost]
    public int Post(MemberInRole obj)
    {
        return Provider.MemberInRole.Save(obj);
    }
}