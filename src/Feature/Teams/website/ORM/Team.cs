namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;


    public class TeamMap : SitecoreGlassMap<ITeam>
    {
        private const string TemplateId = "{FF34C006-BCD7-49CF-9B17-D72917F4E18B}";
        private const string TeamNameFieldId = "{2CD222E4-ACC3-470C-847E-80A58A3C560E}";
        private const string CountryFieldId = "{47066361-2E99-429E-93F7-5F2CD6C9FD73}";
        private const string CategoryFieldId = "{5EBB2B1F-274C-4E72-94FE-9696E3A108C8}";
        private const string GitHubLinkFieldId = "{24977A58-3223-45CF-AC9D-A850AD02C3EA}";
        private const string IsWinnerFieldId = "{48A872B5-2B19-4F43-8839-806E858EB3B6}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.EnforceTemplate();
                config.Field(f => f.TeamName).FieldId(TeamNameFieldId);
                config.Field(f => f.Country).FieldId(CountryFieldId);                
                config.Children(f => f.Members);
                config.Field(f => f.Created).FieldId(Sitecore.FieldIDs.Created);
                config.Field(f => f.Category).FieldId(CategoryFieldId);
                config.Field(f => f.GitHubLink).FieldId(GitHubLinkFieldId);
                config.Field(f => f.IsWinner).FieldId(IsWinnerFieldId);
            });
        }
    }
}
