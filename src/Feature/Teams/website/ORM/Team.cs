namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;


    public class TeamMap : SitecoreGlassMap<ITeam>
    {
        private const string TemplateId = "{FF34C006-BCD7-49CF-9B17-D72917F4E18B}";
        private const string TeamNameFieldId = "{2CD222E4-ACC3-470C-847E-80A58A3C560E}";
        private const string CountryFieldId = "{47066361-2E99-429E-93F7-5F2CD6C9FD73}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.Field(f => f.TeamName).FieldId(TeamNameFieldId);
                config.Field(f => f.Country).FieldId(CountryFieldId);
                config.Children(f => f.Members);
                config.Field(f => f.Created).FieldId(Sitecore.FieldIDs.Created);
            });
        }
    }
}
