namespace WebAppChat.Model;

public class Message
{
    public string MessageId { get; set; }
    public string SenderId { get; set; }
    public string ReceiveId { get; set; }
    public string Content { get; set; }
    public DateTime CreateDate { get; set; }
}