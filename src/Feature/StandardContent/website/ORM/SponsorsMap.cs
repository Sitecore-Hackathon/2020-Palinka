namespace Hackathon.Feature.StandardContent.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.StandardContent.Models;

    public class SponsorsMap : SitecoreGlassMap<ISponsors>
    {
        private const string TemplateId = "{2C829150-5E6E-433A-97EB-CD20BFC65466}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.Children(t => t.Sponsors);
            });
        }
    }
}
