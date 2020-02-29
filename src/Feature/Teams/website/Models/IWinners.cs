namespace Hackathon.Feature.Teams.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The winners model
    /// </summary>
    public interface IWinners : IGlassBase
    {
        /// <summary>
        /// Gets or sets the current winners.
        /// </summary>
        /// <value>
        /// The current winners.
        /// </value>
        IEnumerable<ITeam> CurrentWinners { get; set; }

        /// <summary>
        /// Gets or sets the previous winners.
        /// </summary>
        /// <value>
        /// The previous winners.
        /// </value>
        IEnumerable<ITeam> PreviousWinners { get; set; }
    }
}
