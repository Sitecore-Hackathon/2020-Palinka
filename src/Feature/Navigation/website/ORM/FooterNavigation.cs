namespace Hackathon.Feature.Navigation.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Navigation.Models;

    public class FooterNavigationMap
    {
        private const string TemplateId = "{1EE09B66-F50E-44DB-81C6-919723003527}";
        private const string CopyrightTextFieldId = "{C1745165-D2BA-45B0-BC4B-88247418F9C7}";
        private const string LinksFieldId = "{4F7D4B1C-E6D3-423A-827E-214F09E9C8EC}";
        private const string LinksTitleFieldId = "{6743E1AD-EF01-4F5F-8F0C-0EDD11EE1819}";
        private const string CenterColumnFieldId = "{286B3D46-05BF-4E67-8CB8-C20634578DD9}";
        private const string PinterestWidgetFieldId = "{01E07ABD-BB4B-4DC5-8B52-B57C70E30C05}";

        public class ImageMap : SitecoreGlassMap<IFooterNavigation>
        {
            public override void Configure()
            {
                Map(config =>
                {
                    config.AutoMap();
                    config.TemplateId(TemplateId);
                    config.Field(f => f.CopyrightText).FieldId(CopyrightTextFieldId);
                    config.Field(f => f.Links).FieldId(LinksFieldId);
                    config.Field(f => f.LinksTitle).FieldId(LinksTitleFieldId);
                    config.Field(f => f.CenterColumn).FieldId(CenterColumnFieldId);
                    config.Field(f => f.PinterestWidget).FieldId(PinterestWidgetFieldId);                    
                });
            }
        }
    }
}
