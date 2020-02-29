namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;


    public class TeamsFolderReferenceMap : SitecoreGlassMap<ITeamsFolderReference>
    {
        private const string TeamsTitle = "{2D0A26BB-8C8D-48CA-BB1F-E76461E6C239}";
        private const string TeamsFolder = "{BE23B3E2-D583-428C-AFDF-2EB54CEC82CA}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.TeamsTitle).FieldId(TeamsTitle);
                config.Field(f => f.TeamsFolder).FieldId(TeamsFolder);
            });
        }
    }
}
