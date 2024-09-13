namespace Euro.Models;

public class RoundRepository : BaseRepository
{
    public RoundRepository(EuroContext context) : base(context)
    {
    }

    public List<Round> GetRounds()
    {
        return Context.Round.ToList();
    }

    public int Add(Round obj)
    {
        Context.Round.Add(obj);
        return Context.SaveChanges();
    }

    public int Edit(Round obj)
    {
        Context.Round.Update(obj);
        return Context.SaveChanges();
    }

    public int Delete(byte id)
    {
        Context.Round.Remove(new Round { RoundId = id });
        return Context.SaveChanges();
    }

    public Round? GetRound(byte id)
    {
        return Context.Round.Find(id);
    }
}