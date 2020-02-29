namespace Hackathon.Feature.Navigation.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    public interface IFooterNavigation : IGlassBase
    {
        string CopyrightText { get; set; }

        IEnumerable<IGeneralLink> Links { get; set; }
    }
}
