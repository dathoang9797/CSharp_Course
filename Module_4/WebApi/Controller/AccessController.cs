using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccessController : BaseController
{
    [HttpGet]
    public IEnumerable<Access> GetAccesses()
    {
        var list = Provider.Access.GetAccesses();
        var dictAccess = new Dictionary<int, List<Access>>();
        var accesses = new List<Access>();
        foreach (var item in list)
        {
            if (item.ParentId is null)
            {
                accesses.Add(item);
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

        foreach (var item in list)
        {
            if (dictAccess.ContainsKey(item.AccessId))
                item.Children = dictAccess[item.AccessId];
        }

        return accesses;
    }
}