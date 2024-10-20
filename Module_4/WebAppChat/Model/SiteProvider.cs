using WebAppChat.Repository;

namespace WebAppChat.Models;

public class SiteProvider : BaseProvider
{
    public SiteProvider(IConfiguration configuration) : base(configuration)
    {
    }

    private MessageRepository message;
    public MessageRepository Message => message ??= new MessageRepository(Connection);
    
    private MemberRepository member;
    public MemberRepository Member => member ??= new MemberRepository(Connection);
}