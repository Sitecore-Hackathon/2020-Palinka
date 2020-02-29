namespace Hackathon.Feature.Navigation.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Navigation.Models;

    public class NavigationBaseMap
    {
        public class ImageMap : SitecoreGlassMap<INavigationBase>
        {
            private const string NavigationTitleFieldId = "{8927C543-E28B-44B9-AD06-DFFBB51A471D}";
            private const string HideInNavigationFieldId = "{9AE137F5-6D7C-4B66-920E-AFF7AE8CE7D3}";

            public override void Configure()
            {
                Map(config =>
                {
                    config.AutoMap();
                    config.Field(f => f.NavigationTitle).FieldId(NavigationTitleFieldId);
                    config.Field(f => f.HideInNavigation).FieldId(HideInNavigationFieldId);
                    config.Info(f => f.PageUrl).InfoType(Glass.Mapper.Sc.Configuration.SitecoreInfoType.Url);
                    config.Children(f => f.SubPages);
                });
            }
        }
    }
}
