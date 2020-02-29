namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;

    public class TeamMemberMap : SitecoreGlassMap<ITeamMember>
    {
        private const string TemplateId = "{3B6BCE5F-C144-42B0-81DE-18C882DB72F3}";
        private const string FirstName = "{6AE5CB90-D331-43D0-A91A-C4421E0E7425}";
        private const string LastName = "{40FBDA9D-9E22-420E-8949-7088C303F243}";
        private const string Twitter = "{EAA24DC6-6986-42EB-8C16-48A4477CFE8C}";
        private const string LinkedIn = "{7A833513-BDD1-4562-B9F0-ACC827B3FDB0}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.Field(f => f.FirstName).FieldId(FirstName);
                config.Field(f => f.LastName).FieldId(LastName);
                config.Field(f => f.Twitter).FieldId(Twitter);
                config.Field(f => f.LinkedIn).FieldId(LinkedIn);
            });
        }
    }
}
