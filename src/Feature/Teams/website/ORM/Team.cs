namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;

    public class TeamMap : SitecoreGlassMap<ITeam>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Constants.Team.TemplateId);
                config.Field(f => f.TeamName).FieldId(Constants.Team.TeamNameFieldId);
                config.Field(f => f.Country).FieldId(Constants.Team.CountryFieldId);
                config.Field(f => f.Email).FieldId(Constants.Team.EmailFieldId);
                config.Children(f => f.Members);
                config.Field(f => f.Created).FieldId(Sitecore.FieldIDs.Created);
                config.Field(f => f.Category).FieldId(Constants.Team.CategoryFieldId);
                config.Field(f => f.GitHubLink).FieldId(Constants.Team.GitHubLinkFieldId);
            });
        }
    }
}
