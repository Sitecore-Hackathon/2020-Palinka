using Glass.Mapper.Sc.Fields;

namespace Hackathon.Foundation.ORM.Models
{
    public interface IImage : IGlassBase
    {
        Image Image { get; set; }
    }
}
