namespace Hackathon.Feature.Teams.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    public interface ITeamsFolder : IGlassBase
    {
        IEnumerable<ITeam> Teams { get; set; }
    }
}
