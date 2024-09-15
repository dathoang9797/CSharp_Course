using Microsoft.AspNetCore.Identity;
using WebAppStore.Model;

namespace WebAppStore.Repository;

public class RoleRepository
{
    private RoleManager<IdentityRole> Manager { get; set; }

    public RoleRepository(RoleManager<IdentityRole> manager)
    {
        Manager = manager;
    }
    
    public List<IdentityRole> GetRoles()
    {
        return Manager.Roles.ToList();
    }

    public async Task<IdentityResult?> Add(IdentityRole obj)
    {
        return await Manager.CreateAsync(obj);
    }
    
    public async Task<IdentityResult?> Delete(string id)
    {
        var user = await Manager.FindByIdAsync(id);
        if (user != null)
        {
            return await Manager.DeleteAsync(user);
        }

        return null;
    }
}