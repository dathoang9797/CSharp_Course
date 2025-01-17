using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebKoi.Model;

namespace WebKoi.Services;

public class Notification : Hub
{
    public async Task SendAsync(string msg, Customer obj)
    {
        await Clients.All.SendAsync("receiveMsg", msg, obj);
    }
}