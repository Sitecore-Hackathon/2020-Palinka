using Hackathon.Feature.Navigation.Models;
using Hackathon.Feature.Navigation.ViewModels;
using Hackathon.Foundation.Content.Repositories;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace Hackathon.Feature.Navigation.Controllers
{
    public class NavigationController : SitecoreController
    {
        private readonly IContextRepository contextRepository;

        private readonly IContentRepository contentRepository;

        private const string FooterSettingRelativePath = "/Global/Navigation/FooterNavigation";

        private const string SocialLinksRelativePaths = "/Global/Navigation/SocialLinks";

        public NavigationController(IContextRepository contextRepository, IContentRepository contentRepository)
        {
            this.contextRepository = contextRepository;
            this.contentRepository = contentRepository;
        }

        public ActionResult TopNavigation()
        {
            var model = new TopNavigation();
            var homeItem = contextRepository.GetHomeItem<INavigationBase>();
            model.Pages = homeItem.SubPages.Where(t => !t.HideInNavigation).ToArray();

            string socialLinksPath = Sitecore.Context.Site.RootPath + SocialLinksRelativePaths;
            model.SocialLinks = contentRepository.GetItem<ISocialNavigation>(new Glass.Mapper.Sc.GetItemByPathOptions(socialLinksPath)).SocialLinks;
            return View(model);
        }

        public ActionResult FooterNavigation()
        {
            string settingsPath = Sitecore.Context.Site.RootPath + FooterSettingRelativePath;
            var model = contentRepository.GetItem<IFooterNavigation>(new Glass.Mapper.Sc.GetItemByPathOptions(settingsPath));
            if (model != null)
            {
                return View(model);
            }

            return new EmptyResult();
        }
    }
}
