namespace Hackathon.Feature.StandardContent.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    public interface ISponsors : IGlassBase
    {
        IEnumerable<ISponsor> Sponsors { get; set; }
    }
}
