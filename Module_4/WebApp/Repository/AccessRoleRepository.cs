using System.Data;
using System.Net.Http.Headers;
using WebApp.Models;

namespace WebApp.Repository;

public class AccessRoleRepository : BaseRepository
{
    public AccessRoleRepository(IDbConnection connection, IConfiguration configuration) : base(connection,
        configuration)
    {
    }

    public async Task<int> SaveAsync(AccessRole obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.PostAsJsonAsync($"accessrole", obj);
        if (rsp.IsSuccessStatusCode)
            return await rsp.Content.ReadFromJsonAsync<int>();
        
        return -1;
    }
}