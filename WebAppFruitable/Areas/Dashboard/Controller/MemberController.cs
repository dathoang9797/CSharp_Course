using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Controllers;
using WebAppFruitable.Model;
using WebAppFruitable.Services;

namespace WebAppFruitable.Areas.Dashboard.Controller;

[Area("dashboard")]
public class MemberController : BaseController
{
    [Authorize]
    public IActionResult Index()
    {
        var listMember = Provider.Member.GetMembers();
        ViewBag.Roles = Provider.Role.GetRoles();
        return View(listMember);
    }

    [Authorize]
    [Route("/dashboard/member/roles/{memberId}")]
    public IActionResult Roles([FromRoute] string memberId)
    {
        if (string.IsNullOrWhiteSpace(memberId))
            return Redirect("/dashboard/member");

        var listRolesByMember = Provider.Role.GetRolesByMember(memberId);
        return View(listRolesByMember);
    }

    [Authorize]
    [HttpPost]
    [Route("/dashboard/member/roles")]
    public IActionResult SaveMemberInRole(MemberInRole obj)
    {
        return Json(Provider.MemberInRole.AddAsync(obj));
    }

    [Authorize]
    [Route("/dashboard/member/create")]
    public IActionResult Add(MemberCreate obj)
    {
        try
        {
            const string defaultPassword = "1";
            var entity = new Member()
            {
                MemberId = Guid.NewGuid().ToString().Replace("-", string.Empty),
                Email = obj.Email,
                Password = Helper.HashPassword(defaultPassword),
                Surname = obj.SurName ?? string.Empty,
                GivenName = obj.GivenName,
                CreatedDate = DateTime.UtcNow
            };

            var ret = Provider.Member.Add(entity);
            if (ret < 0)
            {
                TempData["ErrorMessage"] = "Có gì đó không ổn";
            }
            else
            {
                {
                    var memberInRole = new MemberInRole()
                    {
                        MemberId = entity.MemberId,
                        RoleId = obj.RoleId
                    };
                    _ = Provider.MemberInRole.AddAsync(memberInRole);
                }
            }

            return Redirect("/dashboard/member");
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is SqlException sqlEx)
            {
                var errorCode = sqlEx.Number;
                if (errorCode == 2627)
                {
                    TempData["ErrorMessage"] = "Email đã tồn tại";
                }
            }
            else
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return Redirect("/dashboard/member");
        }
    }

    [Authorize]
    [HttpPost]
    [Route("/dashboard/member/delete/{memberId}")]
    public IActionResult Delete([FromRoute] string memberId)
    {
        if (string.IsNullOrWhiteSpace(memberId))
        {
            TempData["ErrorMessage"] = "MemberId không tồn tại";
            return Redirect("/dashboard/member");
        }

        var listRolesByMember = Provider.Role.GetRolesByMember(memberId);
        var isMemberAdmin = listRolesByMember.Any(i => i.Checked == 1 && i.RoleName == "Admin");
        if (isMemberAdmin)
        {
            TempData["ErrorMessage"] = "Không thể xóa member admin";
            return Redirect("/dashboard/member");
        }

        var ret = Provider.Member.Delete(memberId);
        if (ret == -1)
        {
            TempData["ErrorMessage"] = "Có gì đó không ổn";
            return Redirect("/dashboard/member");
        }

        return Redirect("/dashboard/member");
    }

    [HttpGet]
    [Route("/dashboard/member/{memberId}")]
    public async Task<ActionResult> Update([FromRoute] string memberId)
    {
        var product = await Provider.Member.GetMemberById(memberId);
        return Json(product);
    }

    [HttpPost]
    [Route("/dashboard/member/update")]
    public async Task<ActionResult> Update(MemberUpdate obj)
    {
        var entityMember = await Provider.Member.GetMember(obj.Email);
        if (entityMember == null)
        {
            TempData["ErrorMessage"] = "Member không tồn tại";
            return Redirect("/dashboard/member");
        }

        entityMember.GivenName = obj.GivenName;
        entityMember.Surname = obj.SurName;
        entityMember.Email = obj.Email;
        entityMember.UpdatedDate = DateTime.UtcNow;
        var ret = Provider.Member.Update(entityMember);
        if (ret > -1)
        {
            TempData["Msg"] = "Update successfully!";
        }
        else
        {
            TempData["Msg"] = "Update not successful.";
        }

        return Redirect("/dashboard/member");
    }
}