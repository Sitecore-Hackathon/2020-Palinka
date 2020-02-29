using Hackathon.Feature.Hero.Models;
using Hackathon.Foundation.Search.Models;

namespace Hackathon.Feature.Hero.Services
{
    public interface IHeroService
    {
        IHero GetHeroItems();
        BaseSearchResultItem GetHeroImagesSearch();
        bool IsExperienceEditor { get; }
    }
}
