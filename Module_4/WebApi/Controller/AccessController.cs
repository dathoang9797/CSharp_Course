using System.Collections;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccessController : BaseController
{
    [HttpGet]
    [Authorize]
    public IEnumerable<Access> GetAccesses()
    {
        var list = Provider.Access.GetAccesses();
        var dictAccess = new Dictionary<int, List<Access>>();
        var listAccesses = new List<Access>();
        var enumerable = list.ToList();

        foreach (var item in enumerable)
        {
            if (item.ParentId is null)
            {
                listAccesses.Add(item);
            }
            else
            {
                var key = item.ParentId.Value;
                if (!dictAccess.ContainsKey(key))
                {
                    dictAccess[key] = new List<Access>();
                }

                dictAccess[key].Add(item);
            }
        }

        foreach (var item in enumerable)
        {
            if (dictAccess.TryGetValue(item.AccessId, out var value))
                item.Children = value;
        }

        return listAccesses;
    }

    [HttpPost]
    public int Add(Access obj)
    {
        return Provider.Access.Add(obj);
    }

    [HttpGet("parents")]
    public IEnumerable<Access> GetParents()
    {
        return Provider.Access.GetParents();
    }

    [HttpGet("accesscheckeds/{id}")]
    public IEnumerable<AccessChecked> GetAccessChecked(int id)
    {
        return Provider.Access.GetAccessCheckedsByRole(id);
    }
    
    [Authorize]
    [HttpGet("accesschecked")]
    public IEnumerable<AccessChecked>? AccessChecked()
    {
        // var list = Provider.Access.GetAccesses();
        var memberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(memberId))
            return null;

        var list = Provider.Access.GetAccessesChecked(memberId);
        var dictAccess = new Dictionary<int, List<AccessChecked>>();
        var listAccesses = new List<AccessChecked>();
        var listAccessChecked = list.ToList();

        foreach (var item in listAccessChecked)
        {
            if (item.ParentId is null)
            {
                listAccesses.Add(item);
            }
            else
            {
                var key = item.ParentId.Value;
                if (!dictAccess.ContainsKey(key))
                {
                    dictAccess[key] = new List<AccessChecked>();
                }

                dictAccess[key].Add(item);
            }
        }

        foreach (var item in listAccessChecked)
        {
            if (dictAccess.TryGetValue(item.AccessId, out var value))
                item.Children = value;
        }

        return listAccesses;
    }
}