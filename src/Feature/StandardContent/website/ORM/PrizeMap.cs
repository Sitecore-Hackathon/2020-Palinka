using Glass.Mapper.Sc.Maps;
using Hackathon.Feature.StandardContent.Models;

namespace Hackathon.Feature.StandardContent.ORM
{
    public class PrizeMap : SitecoreGlassMap<IPrize>
    {
        private const string TitleFieldId = "{460827DC-9DB1-4885-A99C-FA3080FA514F}";
        private const string IconFieldId = "{E38510C4-6856-40B4-8653-4A21DE1FB180}";
        private const string DescriptionFieldId = "{2FC81E77-5B57-4FC1-9FF8-FE50B6FD4434}";
        private const string LinkTextFieldId = "{D91DF154-E551-44E4-A87D-14240068B933}";
        private const string LinkFieldId = "{C425299C-0F6F-4EF3-B690-D9A56839E4E9}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.Title).FieldId(TitleFieldId);
                config.Field(f => f.Icon).FieldId(IconFieldId);
                config.Field(f => f.Description).FieldId(DescriptionFieldId);
                config.Field(f => f.LinkText).FieldId(LinkTextFieldId);
                config.Field(f => f.Link).FieldId(LinkFieldId);
            });
        }
    }
}
