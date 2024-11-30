using WebAppAuthentication.Model;
using WebAppFruitables.Model;

namespace WebAppFruitables.Repository;

public class SlideRepository : BaseRepository
{
    public SlideRepository(FruitableContext context) : base(context)
    {
    }

    public List<Slide> GetSlide()
    {
        return Context.Slide.ToList();
    }
}