using Microsoft.EntityFrameworkCore;

namespace Euro.Models;

public class MatchRepository : BaseRepository
{
    public MatchRepository(EuroContext context) : base(context)
    {
    }

    public List<Match> GetMatch() =>
        Context.Match.Include(p => p.Round).Include(p => p.Team1).Include(p => p.Team2).ToList();

    public int Add(Match obj)
    {
        Context.Match.Add(obj);
        return Context.SaveChanges();
    }

    public Match? GetMatch(int id) => Context.Match.Find(id);

    public int Edit(Match obj)
    {
        Context.Match.Update(obj);
        return Context.SaveChanges();
    }

    public int Delete(byte id)
    {
        Context.Match.Remove(new Match { MatchId = id });
        return Context.SaveChanges();
    }
}