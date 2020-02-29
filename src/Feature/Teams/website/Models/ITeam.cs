namespace Hackathon.Feature.Teams.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The team model
    /// </summary>
    public interface ITeam : IGlassBase
    {
        string TeamName { get; set; }

        string Country { get; set; }

        IEnumerable<ITeamMember> Members { get; set; }

        DateTime Created { get; set; }

        ICategory Category { get; set; }

        string GitHubLink { get; set; }
    }
}
