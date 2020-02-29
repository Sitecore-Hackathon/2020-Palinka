namespace Hackathon.Feature.Judge.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    public interface IEventPage : IGlassBase
    {
        IEnumerable<IJudge> CommunityJudges { get; set; }
        IEnumerable<IJudge> SitecoreJudges { get; set; }
    }
}
