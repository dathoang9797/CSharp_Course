using Microsoft.AspNetCore.SignalR;

namespace WebAppChat.Services;

public class ChatHub : Hub
{
    public async Task SendMessageAsync(string userId, string sender, string msg)
    {
        await Clients.User(userId).SendAsync("receiveMsg", new { Sender = sender, Msg = msg });
    }
}