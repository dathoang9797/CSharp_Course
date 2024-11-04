using System.Collections.Generic;
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
            "INSERT INTO Message(SenderId, ReceiveId, Content, Type) VALUES (@SenderId, @ReceiveId, @Content, @Type)", new
            {
                obj.SenderId, obj.ReceiveId, obj.Content, obj.Type
            });
    }

    public IEnumerable<Message> GetMessages(string senderId, string receiveId)
    {
        return Connection.Query<Message>("GetMessages", new { SenderId = senderId, ReceiveId = receiveId },
            commandType: CommandType.StoredProcedure);
    }
}