using Microsoft.AspNetCore.SignalR;
using WebAppProduct.Models;

namespace WebAppProduct.Services;

public class Notification : Hub
{
    public async Task SendAsync(string msg, Customer obj)
    {
        await Clients.All.SendAsync("receiveMsg", msg, obj);
    }
}