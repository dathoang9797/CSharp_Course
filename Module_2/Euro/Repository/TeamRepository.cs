namespace Euro.Models;

public class TeamRepository:BaseRepository
{
    public TeamRepository(EuroContext context) : base(context)
    {
    }

    public List<Team> GetTeams()
    {
        return Context.Teams.ToList();
    }

    public int Add(Team obj)
    {
        Context.Teams.Add(obj);
        return Context.SaveChanges();
    }

    public int Delete(short id)
    {
        Context.Teams.Remove(new Team() { TeamId = id });
        return Context.SaveChanges();
    }

    public Team GetTeam(short id)
    {
        return Context.Teams.Find(id) ?? throw new InvalidOperationException();
    }

    public int Edit(Team obj)
    {
        Context.Teams.Update(obj);
        return Context.SaveChanges();
    }
}