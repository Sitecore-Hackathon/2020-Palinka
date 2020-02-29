namespace Hackathon.Feature.Teams.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The team model
    /// </summary>
    public interface ITeamStatistics : IGlassBase
    {
        string Text { get; set; }

        ITeamsFolder TeamsFolder { get; set; }
    }
}
