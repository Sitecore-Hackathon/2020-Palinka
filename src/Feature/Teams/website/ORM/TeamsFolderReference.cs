namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;


    public class TeamsFolderReferenceMap : SitecoreGlassMap<ITeamsFolderReference>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Constants.TeamFolderReference.TemplateId);
                config.Field(f => f.TeamsTitle).FieldId(Constants.TeamFolderReference.TeamsTitle);
                config.Field(f => f.TeamsFolder).FieldId(Constants.TeamFolderReference.TeamsFolder);
            });
        }
    }
}
