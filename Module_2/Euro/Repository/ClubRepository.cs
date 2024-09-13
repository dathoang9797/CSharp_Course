using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Models;

public class ClubRepository : BaseRepository
{
    public ClubRepository(EuroContext context) : base(context)
    {
    }

    public List<Club?> GetClubs()
    {
        return Context.Club.ToList();
    }

    public int Add(Club? obj)
    {
        Context.Club.Add(obj);
        return Context.SaveChanges();
    }

    public Club? GetClub(short id)
    {
        return Context.Club.Find(id);
    }

    public int Edit(short id, Club obj, IFormFile FILE)
    {
        Context.Club.Remove(new Club() { Id = id });
        return Context.SaveChanges();
    }

    public int Edit(Club? obj)
    {
        if (obj != null)
        {
            Context.Club.Update(obj);
        }
        return Context.SaveChanges();
    }

    public int Delete(short id)
    {
        Context.Club.Remove(new Club() { Id = id });
        return Context.SaveChanges();
    }

    public int UpdateLogo(short id, string logo)
    {
        var obj = Context.Club.Find(id);
        if (obj != null)
        {
            obj.Logo = logo;
            return Context.SaveChanges();
        }

        return -1;
    }
}