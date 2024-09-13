using Euro.Models;

namespace WebApplication1.Models;

public class SiteProvider
{
    private EuroContext context;
    private RoundRepository round = null!;
    private PositionRepository position = null!;
    private PlayerRepository player = null!;
    private ClubRepository club = null!;
    private TeamRepository team = null!;
    private MatchRepository match = null!;
    private SoccerRepository soccer = null!;
    
    //contructor
    public SiteProvider(EuroContext Context)
    {
        context = Context;
    }

    //Properties
    public RoundRepository Round
    {
        get
        {
            if (round is null)
            {
                round = new RoundRepository(context);
            }

            return round;
        }
    }
    
    public PositionRepository Position => position ??= new PositionRepository(context);
    public PlayerRepository Player => player ??= new PlayerRepository(context);
    public ClubRepository Club => club ??= new ClubRepository(context);
    public TeamRepository Team => team ??= new TeamRepository(context);
    public MatchRepository Match => match ??= new MatchRepository(context);
    public SoccerRepository Soccer => soccer ??= new SoccerRepository(context);


}