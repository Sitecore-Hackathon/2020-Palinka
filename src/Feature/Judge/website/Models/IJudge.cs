namespace Hackathon.Feature.Judge.Models
{
    using Hackathon.Foundation.ORM.Models;
    using System.Drawing;

    public interface IJudge : IGlassBase
    {
        string Fullname { get; set; }
        Image Photo { get; set; }
        string Twitter { get; set; }
        string LinkedIn { get; set; }
        string Bio { get; set; }
    }
}
