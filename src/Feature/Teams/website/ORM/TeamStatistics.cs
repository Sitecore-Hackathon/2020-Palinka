namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;


    public class TeamsStatisticsMap : SitecoreGlassMap<ITeamStatistics>
    {
        private const string TextFieldId = "{99D2D89D-0924-40D4-B9AE-B3F943606FD2}";

        private const string TeamsFolderFieldId = "{F20331AD-5950-44ED-A565-439C643A13B6}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.Text).FieldId(TextFieldId);
                config.Field(f => f.TeamsFolder).FieldId(TeamsFolderFieldId);
            });
        }
    }
}
