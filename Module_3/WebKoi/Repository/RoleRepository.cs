using System.Collections.Generic;
using System.Linq;
using WebKoi.Model;

namespace WebKoi.Repository;

public class RoleRepository : BaseRepository
{
    public RoleRepository(KoiContext context) : base(context)
    {
    }

    public List<Role> GetRoles()
    {
        return Context.Roles.ToList();
    }
}