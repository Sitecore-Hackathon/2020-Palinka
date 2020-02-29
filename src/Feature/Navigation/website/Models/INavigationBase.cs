namespace Hackathon.Feature.Navigation.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    public interface INavigationBase : IGlassBase
    {
        string NavigationTitle { get; set; }

        bool HideInNavigation { get; set; }

        string PageUrl { get; set; }

        bool HasUrl { get; set; }

        IEnumerable<INavigationBase> SubPages { get; set; }
    }
}
