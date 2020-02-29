namespace Hackathon.Feature.Teams.ViewModels
{
    using Hackathon.Feature.Teams.Models;
    using System.Collections.Generic;

    public class TeamList
    {
        public string Title { get; set; }
        public IEnumerable<ITeam> Teams { get; set; }
    }
}
