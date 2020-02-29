namespace Hackathon.Feature.Navigation.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Navigation.Models;

    public class SocialLinkMap: SitecoreGlassMap<ISocialLink>
    {
        private const string LinkFieldId = "{857A3A23-8390-4424-9727-7E1709DF514F}";
        private const string SocialTypeFieldId = "{CB3F43B5-B230-4B5F-BBD8-907B6D03A59F}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.Link).FieldId(LinkFieldId);
                config.Field(f => f.SocialType).FieldId(SocialTypeFieldId);
            });
        }
    }
}
