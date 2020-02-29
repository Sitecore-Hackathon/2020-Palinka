namespace Hackathon.Feature.StandardContent.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.StandardContent.Models;

    public class TestimonialMap : SitecoreGlassMap<ITestimonial>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.Quote).FieldName("Quote");
                config.Field(f => f.NameField).FieldName("Name");
                config.Field(f => f.SubText).FieldName("Sub Text");
                config.Field(f => f.Image).FieldName("Image");
            });
        }
    }
}
