namespace Hackathon.Feature.StandardContent.Models
{
    using Glass.Mapper.Sc.Fields;
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    /// <summary>
    /// IPrize Interface
    /// </summary>
    /// <seealso cref="Hackathon.Foundation.ORM.Models.IGlassBase" />
    public interface IPrize : IGlassBase
    {
        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        /// <value>
        /// The Title.
        /// </value>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        string Icon { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the link text.
        /// </summary>
        /// <value>
        /// The link text.
        /// </value>
        string LinkText { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        Link Link { get; set; }
    }
}