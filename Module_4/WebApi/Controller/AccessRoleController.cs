using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccessRoleController : BaseController
{
   [HttpPost]
   public int Post(AccessRole obj)
   {
      return Provider.AccessRole.Save(obj);
   }
}