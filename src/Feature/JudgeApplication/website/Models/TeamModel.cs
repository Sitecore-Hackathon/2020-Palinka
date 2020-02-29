using System.Collections.Generic;

namespace Hackathon.Feature.JudgeApplication.Models
{
    /// <summary>
    /// Team Model Contract
    /// </summary>
    public class TeamModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        /// <value>
        /// The name of the team.
        /// </value>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets the git hub link.
        /// </summary>
        /// <value>
        /// The git hub link.
        /// </value>
        public string GitHubLink { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TeamModel"/> is reviewed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if reviewed; otherwise, <c>false</c>.
        /// </value>
        public bool Reviewed { get; set; }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public List<TeamMember> Member { get; set; }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        /// <value>
        /// The point.
        /// </value>
        public string Point { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }
    }
}