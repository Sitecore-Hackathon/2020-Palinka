using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using Hackathon.Foundation.ORM.Models;

namespace Hackathon.Feature.StandardContent.Models
{
    public interface IText : IGlassBase
    {
        string Text { get; set; }
    }
}
