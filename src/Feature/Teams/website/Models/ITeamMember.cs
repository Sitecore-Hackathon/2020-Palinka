namespace Hackathon.Feature.Teams.Models
{
    using Glass.Mapper.Sc.Fields;
    using Hackathon.Foundation.ORM.Models;

    public interface ITeamMember : IGlassBase
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string Twitter { get; set; }

        string LinkedIn { get; set; }
    }
}
