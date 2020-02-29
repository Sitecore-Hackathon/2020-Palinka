namespace Hackathon.Feature.Teams.Models
{
    using Glass.Mapper.Sc.Fields;

    public interface ITeamMember
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string Twitter { get; set; }

        string LinkedIn { get; set; }
    }
}
