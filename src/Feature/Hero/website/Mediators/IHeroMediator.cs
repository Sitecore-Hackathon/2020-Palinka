using Hackathon.Feature.Hero.ViewModels;
using Hackathon.Foundation.Core.Models;

namespace Hackathon.Feature.Hero.Mediators
{
    public interface IHeroMediator
    {
        MediatorResponse<HeroViewModel> RequestHeroViewModel();
    }
}
