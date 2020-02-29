namespace Hackathon.Feature.Navigation.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    public interface ISocialNavigation : IGlassBase
    {
        IEnumerable<ISocialLink> SocialLinks { get; set; }
    }
}
