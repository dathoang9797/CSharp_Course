namespace Euro.Models;

public class PlayerRepository : BaseRepository
{
    public PlayerRepository(EuroContext context) : base(context)
    {
    }

    public List<Player> GetPlayers() => Context.Player.ToList();

    public int Add(Player obj)
    {
        Context.Player.Add(obj);
        return Context.SaveChanges();
    }

    public Player GetPlayer(int id) => Context.Player.Find(id);

    public int Edit(Player obj)
    {
        Context.Player.Update(obj);
        return Context.SaveChanges();
    }

    public int Delete(byte id)
    {
        Context.Player.Remove(new Player { PlayerId = id });
        return Context.SaveChanges();
    }
}