using Hackathon.Foundation.ORM.Models;

namespace Hackathon.Feature.StandardContent.Models
{
    public interface IFaq : IGlassBase
    {
        string Question { get; set; }

        string Answer { get; set; }
    }
}
