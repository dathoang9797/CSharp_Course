using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebApp.Models;

namespace WebApp.Repository;

public class RoleRepository : BaseRepository
{
    public RoleRepository(IDbConnection connection, IConfiguration configuration) : base(connection, configuration)
    {
    }

    public async Task<IEnumerable<RoleChecked>?> GetRolesChecked(string id)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.GetFromJsonAsync<IEnumerable<RoleChecked>>($"role/{id}");
        return rsp;
    }

    public async Task<IEnumerable<Role>?> GetRolesAsync()
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.GetFromJsonAsync<IEnumerable<Role>>($"role");
        return rsp;  
    }
    
    public async Task<Role?> GetRoleAsync(int id)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.GetFromJsonAsync<Role>($"role/details/{id}");
        return rsp;  
    }
}