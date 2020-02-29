namespace Hackathon.Feature.StandardContent.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.StandardContent.Models;

    public class SponsorMap : SitecoreGlassMap<ISponsor>
    {
        private const string TemplateId = "{A1C2C958-C0D8-4755-AA2B-20A6675A89BE}";
        private const string FullnameFieldId = "{792A2C34-EB5A-40A1-9789-A2E2122D32C2}";
        private const string LinkFieldId = "{93F77C49-DC8A-4859-B13A-2567971C5F26}";
        private const string SmallImageFieldId = "{624F2C1A-A103-42B0-9AE6-B13AB3DF4BA6}";
        private const string LargeImageFieldId = "{6B06A116-8744-4E83-A399-53F00CA3B01F}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.Field(f => f.Fullname).FieldId(FullnameFieldId);
                config.Field(f => f.Link).FieldId(LinkFieldId);
                config.Field(f => f.SmallImage).FieldId(SmallImageFieldId);
                config.Field(f => f.LargeImage).FieldId(LargeImageFieldId);
            });
        }
    }
}
