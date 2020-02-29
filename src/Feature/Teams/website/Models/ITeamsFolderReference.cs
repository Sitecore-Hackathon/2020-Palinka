namespace Hackathon.Feature.Teams.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    public interface ITeamsFolderReference : IGlassBase
    {
        string TeamsTitle { get; set; }
        ITeamsFolder TeamsFolder { get; set; }
    }
}
