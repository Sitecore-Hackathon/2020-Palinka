namespace Hackathon.Feature.StandardContent.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.StandardContent.Models;

    public class FaqFolderMap : SitecoreGlassMap<IFaqFolder>
    {
        private const string TemplateId = "{18D4BD2E-BB2C-41D4-81CA-3FCF36F024F5}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.Children(t => t.Faqs);
            });
        }
    }
}
