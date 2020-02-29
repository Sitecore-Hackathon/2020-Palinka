using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Maps;
using Hackathon.Foundation.ORM.Models;

namespace Hackathon.Foundation.ORM
{
    public class CategoryMapping : SitecoreGlassMap<ICategory>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.Title).FieldName("Title");
                config.Field(f => f.Description).FieldName("Description");
            });
        }
    }
}
