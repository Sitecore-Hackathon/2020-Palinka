namespace Hackathon.Feature.StandardContent.Models
{
    using Glass.Mapper.Sc.Fields;
    using Hackathon.Foundation.ORM.Models;
    using System.Collections.Generic;

    /// <summary>
    /// IPrizes Interface
    /// </summary>
    /// <seealso cref="Hackathon.Foundation.ORM.Models.IGlassBase" />
    public interface IPrizes : IGlassBase
    {
        IEnumerable<IPrize> Prizes { get; set; }
    }
}