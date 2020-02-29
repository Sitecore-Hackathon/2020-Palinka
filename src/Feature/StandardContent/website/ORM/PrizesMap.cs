using Glass.Mapper.Sc.Maps;
using Hackathon.Feature.StandardContent.Models;

namespace Hackathon.Feature.StandardContent.ORM
{
    public class PrizesMap : SitecoreGlassMap<IPrizes>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.Prizes).FieldName("Prizes");
            });
        }
    }
}
