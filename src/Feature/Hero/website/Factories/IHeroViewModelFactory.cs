using Hackathon.Feature.Hero.Models;
using Hackathon.Feature.Hero.ViewModels;

namespace Hackathon.Feature.Hero.Factories
{
    public interface IHeroViewModelFactory
    {
        HeroViewModel CreateHeroViewModel(IHero heroItemDataSource, bool isExperienceEditor);
    }
}
