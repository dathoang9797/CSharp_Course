using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class RoleController : BaseController
{
    [HttpGet]
    public IEnumerable<Role> GetRoles()
    {
        return Provider.Role.GetRoles();
    }

    [HttpGet("{id}")]
    public IEnumerable<Role> GetRoles(string id)
    {
        return Provider.Role.GetRolesByMember(id);
    }
}