namespace Hackathon.Feature.Navigation.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Navigation.Models;

    public class SocialNavigationMap: SitecoreGlassMap<ISocialNavigation>
    {
        private const string TemplateId = "{A7C090E1-8F3C-4747-B0D1-A52D2B04F12A}";
        private const string LinksFieldId = "{75753094-8FC4-41D8-A437-A2F526BE431A}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.Field(f => f.SocialLinks).FieldId(LinksFieldId);
            });
        }
    }
}
