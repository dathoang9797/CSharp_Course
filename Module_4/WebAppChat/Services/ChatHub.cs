using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using WebAppChat.Model;
using WebAppChat.Models;

namespace WebAppChat.Services;

public class ChatHub : Hub
{
    private IConfiguration Configuration;
    public ChatHub(IConfiguration configuration) => Configuration = configuration;

    public async Task SendMessageAsync(string userId, string msg)
    {
        if (Context.User is null)
            return;

        var senderId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var senderName = Context.User.FindFirstValue(ClaimTypes.Name);
        if (string.IsNullOrWhiteSpace(senderId) || string.IsNullOrWhiteSpace(senderName))
            return;

        using (var provider = new SiteProvider(Configuration))
        {
            provider.Message.Add(new Message()
            {
                SenderId = senderId,
                ReceiveId = userId,
                Content = msg,
            });
        }

        await Clients.User(userId).SendAsync("receiveMsg", new { Sender = senderName, Msg = msg });
    }
}