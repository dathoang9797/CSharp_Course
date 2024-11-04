using System;

namespace WebAppChat.Model;

public class Message
{
    public string MessageId { get; set; }
    public string SenderId { get; set; }
    public string SenderName { get; set; }

    public string ReceiveId { get; set; }
    public string ReceiveName { get; set; }

    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Type { get; set; }

    public string Date => CreatedDate.ToString("hh:mm");
}