using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using WebAppChat.Model;
using WebAppChat.Models;

namespace WebAppChat.Services;

public class ChatHub(IConfiguration configuration) : Hub
{
    private IConfiguration Configuration = configuration;

    public async Task SuccessAsync(string msg, Member obj)
    {
        if (Clients != null)
            await Clients.All.SendAsync(msg, obj);
    }

    public async Task SendMessageAsync(string userId, string msg, string type = "text")
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
                Type = type
            });
        }

        await Clients.User(userId).SendAsync("receiveMsg",
            new { SenderId = senderId, Sender = senderName, Msg = msg, Type = type });
    }
}