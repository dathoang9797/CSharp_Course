namespace Euro.Models;

public class PositionRepository : BaseRepository
{
    public PositionRepository(EuroContext context) : base(context)
    {
    }

    public List<Position> GetPositions() => Context.Position.ToList();
}