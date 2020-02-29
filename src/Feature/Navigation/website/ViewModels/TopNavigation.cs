namespace Hackathon.Feature.Navigation.ViewModels
{
    using Hackathon.Feature.Navigation.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class TopNavigation
    {
        public IEnumerable<INavigationBase> Pages { get; set; }

        public IEnumerable<ISocialLink> SocialLinks { get; set; }

        public bool HasSubPages(INavigationBase page)
        {
            if (page == null)
            {
                return false;
            }

            return page.SubPages.Any(t => !t.HideInNavigation);
        }

        public IEnumerable<INavigationBase> GetSubPages(INavigationBase page)
        {
            if (page == null)
            {
                return new INavigationBase[0];
            }

            return page.SubPages.Where(t => !t.HideInNavigation).ToArray();
        }
    }
}
