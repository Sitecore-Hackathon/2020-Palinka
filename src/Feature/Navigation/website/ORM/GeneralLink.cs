namespace Hackathon.Feature.Navigation.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Navigation.Models;

    public class GeneralLinkMap
    {
        private const string LinkFieldId = "{FD88489F-8DC3-4EDC-9B02-8880051AE83E}";

        public class ImageMap : SitecoreGlassMap<IGeneralLink>
        {
            public override void Configure()
            {
                Map(config =>
                {
                    config.AutoMap();
                    config.Field(f => f.Link).FieldId(LinkFieldId);
                });
            }
        }
    }
}
