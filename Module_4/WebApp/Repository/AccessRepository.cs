using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebApp.Models;

namespace WebApp.Repository;

public class AccessRepository : BaseRepository
{
    public AccessRepository(IDbConnection connection, IConfiguration configuration) : base(connection, configuration)
    {
    }

    public async Task<IEnumerable<AccessChecked>?> GetAccessesChecked(string token)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var rsp = await client.GetFromJsonAsync<IEnumerable<AccessChecked>>("access/accesscheckeds");
        return rsp;
    }

    public async Task<IEnumerable<AccessChecked>?> GetAccessesCheckedByRole(int id)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.GetFromJsonAsync<IEnumerable<AccessChecked>>($"access/accesscheckeds/{id}");
        return rsp;
    }

    public async Task<IEnumerable<Access>?> GetAccesses(string token)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        if (!string.IsNullOrWhiteSpace(token))
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var rsp = await client.GetFromJsonAsync<IEnumerable<Access>>("access");
        return rsp;
    }

    public async Task<int> AddAsync(Access obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.PostAsJsonAsync("access", obj);
        if (rsp.IsSuccessStatusCode)
        {
            return await rsp.Content.ReadFromJsonAsync<int>();
        }

        return -1;
    }

    public async Task<IEnumerable<Access>?> GetParents(string token)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        if (!string.IsNullOrWhiteSpace(token))
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var rsp = await client.GetFromJsonAsync<IEnumerable<Access>>("access/parents");
        return rsp;
    }
}