namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;


    public class TeamsFolderMap : SitecoreGlassMap<ITeamsFolder>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Children(f => f.Teams);
            });
        }
    }
}
