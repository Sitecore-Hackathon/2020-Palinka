namespace Hackathon.Feature.StandardContent.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    public interface IFaqFolder : IGlassBase
    {
        IEnumerable<IFaq> Faqs { get; set; }
    }
}
