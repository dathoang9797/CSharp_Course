using System.Data;
using Dapper;
using WebAppChat.Model;
using WebAppChat.Services;

namespace WebAppChat.Repository;

public class MessageRepository : BaseRepository
{
    public MessageRepository(IDbConnection connection) : base(connection)
    {
    }

    public int? Add(Message obj)
    {
        return Connection.Execute(
            "INSERT INTO Message(SenderId, ReceiveId, Content) VALUES (@SenderId, @ReceiveId, @Content)", new
            {
                obj.SenderId, obj.ReceiveId, obj.Content
            });
    }
}