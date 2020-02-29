using Hackathon.Foundation.ORM.Models;

namespace Hackathon.Foundation.Content.Tests.Models
{
    public interface ITestItem : IGlassBase
    {
        string Title { get; set; }
    }
}
