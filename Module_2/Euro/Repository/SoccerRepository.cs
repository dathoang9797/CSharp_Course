namespace Euro.Models;

public class SoccerRepository : BaseRepository
{
    public SoccerRepository(EuroContext context) : base(context)
    {
    }

    public List<Soccer> GetSoccers(int page, int size)  {
        return Context.Soccer.Skip((page - 1) * size).Take(size).ToList();
    }

    public List<Soccer> SearchSoccers(string q, int page, int size)
    {
        return Context.Soccer.Where(p => p.Name.Contains(q) || p.Club.Contains(q)).Skip((page - 1) * size).Take(size).ToList();
    }
    
    public int GetCountSearch(string q)
    {
        return Context.Soccer.Count(p => p.Name.Contains(q) || p.Club.Contains(q));
    }
    
    public int GetCount()
    {
        return Context.Soccer.Count();
    }

    public int Add(List<Soccer> list)
    {
        Context.Soccer.AddRange(list);
        return Context.SaveChanges();
    }
}