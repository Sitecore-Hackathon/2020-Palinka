namespace Hackathon.Feature.StandardContent.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    /// <summary>
    ///ICategories Interface
    /// </summary>
    /// <seealso cref="Hackathon.Foundation.ORM.Models.IGlassBase" />
    public interface ICategories : IGlassBase
    {
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        IEnumerable<ICategory> Categories { get; set; }
    }
}