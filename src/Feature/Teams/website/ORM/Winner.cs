namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;


    public class WinnerMap : SitecoreGlassMap<IWinners>
    {
        private const string TemplateId = "{B5355668-FF81-4CDD-879C-04DD0A3223EF}";
        private const string CurrentWinners = "{2429C037-5C0B-4A08-8A60-8F2BCB01BD2E}";
        private const string PreviousWinners = "{151DD313-9F58-4171-A1DF-80836AA4F7D8}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.EnforceTemplate();
                config.Field(f => f.CurrentWinners).FieldId(CurrentWinners);
                config.Field(f => f.PreviousWinners).FieldId(PreviousWinners);       
            });
        }
    }
}
