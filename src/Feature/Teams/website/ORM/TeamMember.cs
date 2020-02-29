namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;

    public class TeamMemberMap : SitecoreGlassMap<ITeamMember>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Constants.TeamMember.TemplateId);
                config.Field(f => f.FirstName).FieldId(Constants.TeamMember.FirstName);
                config.Field(f => f.LastName).FieldId(Constants.TeamMember.LastName);
                config.Field(f => f.Twitter).FieldId(Constants.TeamMember.Twitter);
                config.Field(f => f.LinkedIn).FieldId(Constants.TeamMember.LinkedIn);
            });
        }
    }
}
