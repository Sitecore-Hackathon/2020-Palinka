using Hackathon.Foundation.ORM.Models;
using Glass.Mapper.Sc.Fields;

namespace Hackathon.Feature.StandardContent.Models
{
    public interface ITestimonial : IGlassBase
    {
        string Quote { get; set; }

        string NameField { get; set; }

        string SubText { get; set; }

        Image Image { get; set; }
    }
}
