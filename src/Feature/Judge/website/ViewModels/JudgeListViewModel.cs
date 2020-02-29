namespace Hackathon.Feature.Judge.ViewModels
{
    using Hackathon.Feature.Judge.Models;
    using System.Collections.Generic;

    public class JudgeListViewModel
    {
        public IEnumerable<IJudge> CommunityJudges { get; set; }
        public IEnumerable<IJudge> SitecoreJudges { get; set; }
    }
}
