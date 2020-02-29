namespace Hackathon.Feature.Judge.Models
{
    using System.Collections.Generic;

    public interface IEventPage
    {
        IEnumerable<IJudge> CommunityJudges { get; set; }
        IEnumerable<IJudge> SitecoreJudges { get; set; }
    }
}
