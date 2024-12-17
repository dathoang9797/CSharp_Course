using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;
using WebAppFruitable.Repository;

namespace WebAppFruitable.Repository;

public class RoleRepository : BaseRepository
{
    public RoleRepository(FruitableContext context) : base(context)
    {
    }
    
    public List<Role> GetRoles()
    {
        return Context.Role.ToList();
    }

    public List<RoleChecked> GetRolesByMember(string memberId)
    {
        return Context.Database.SqlQuery<RoleChecked>($"EXEC GetRolesByMember @Id ={memberId}").ToList();
    }
    
    public int Add(Role? role)
    {
        if (role != null)
        {
            Context.Role.Add(role);
            return Context.SaveChanges();
        }

        return -1;
    }
    
    public int Delete(int id)
    {
        var role = Context.Role.Find(id);
        if (role != null)
        {
            Context.Role.Remove(role);
            return Context.SaveChanges();
        }

        return -1;
    }
}