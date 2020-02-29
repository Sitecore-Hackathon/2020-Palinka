namespace Hackathon.Feature.StandardContent.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.StandardContent.Models;

    public class TestimonialSourceMap : SitecoreGlassMap<ITestimonialSource>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.Testimonials).FieldName("Testimonials");
            });
        }
    }
}
