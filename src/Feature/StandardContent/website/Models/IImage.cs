using Glass.Mapper.Sc.Fields;
using Hackathon.Foundation.ORM.Models;

namespace Hackathon.Feature.StandardContent.Models
{
    public interface IImage : IGlassBase
    {
        Image Image { get; set; }
    }
}
