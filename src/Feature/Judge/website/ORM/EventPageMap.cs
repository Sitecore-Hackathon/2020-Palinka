namespace Hackathon.Feature.Judge.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Judge.Models;

    public class EventPageMap : SitecoreGlassMap<IEventPage>
    {
        private const string TemplateId = "{B5355668-FF81-4CDD-879C-04DD0A3223EF}";
        private const string CommunityJudgesFieldId = "{61FC184C-71D7-4592-873C-9621749B5E2E}";
        private const string SitecoreJudgesFieldId = "{C2F69B38-A8BA-45EC-A9A4-9F740E598FCC}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.Field(f => f.CommunityJudges).FieldId(CommunityJudgesFieldId);
                config.Field(f => f.SitecoreJudges).FieldId(SitecoreJudgesFieldId);
            });
        }
    }
}