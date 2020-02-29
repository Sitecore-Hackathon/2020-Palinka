using Glass.Mapper.Sc.Maps;
using Hackathon.Feature.StandardContent.Models;

namespace Hackathon.Feature.StandardContent.ORM
{
    public class ImageMap : SitecoreGlassMap<IImage>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.Image).FieldName("Image");
            });
        }
    }
}
