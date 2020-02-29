namespace Hackathon.Feature.Judge.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Judge.Models;

    public class JudgeMap : SitecoreGlassMap<IJudge>
    {
        private const string TemplateId = "{A32DE60D-8564-4326-8236-5AF25028F7AA}";
        private const string FullnameFieldId = "{0CE82011-206C-407E-8C2B-35844C607728}";
        private const string PhotoFieldId = "{C60C83A7-0A4C-4A68-8119-E617FD49D1EB}";
        private const string TwitterFieldId = "{577EB48D-BAF1-4C3C-B18D-BB372F5AC9ED}";
        private const string LinkedInFieldId = "{8A5B75A7-2AD3-4E3E-8E26-6351679D95E1}";
        private const string BioFieldId = "{33FBA013-B82C-4D0C-B15C-4B0BEE4A502F}";

        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.Field(f => f.Fullname).FieldId(FullnameFieldId);
                config.Field(f => f.Photo).FieldId(PhotoFieldId);
                config.Field(f => f.Twitter).FieldId(TwitterFieldId);
                config.Field(f => f.LinkedIn).FieldId(LinkedInFieldId);
                config.Field(f => f.Bio).FieldId(BioFieldId);
            });
        }
    }
}
