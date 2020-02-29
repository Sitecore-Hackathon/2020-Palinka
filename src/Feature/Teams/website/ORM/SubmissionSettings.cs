namespace Hackathon.Feature.Teams.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.Teams.Models;


    public class SubmissionSettingsMap : SitecoreGlassMap<ISubmissionSettings>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Field(f => f.StartDate).FieldId(Constants.SubmissionSettings.StartDateFieldId);
                config.Field(f => f.EndDate).FieldId(Constants.SubmissionSettings.EndDateFieldId);
                config.Field(f => f.TargetFolder).FieldId(Constants.SubmissionSettings.TargetFieldId);
                config.Field(f => f.EventDate).FieldId(Constants.SubmissionSettings.EventDateFieldId);
            });
        }
    }
}
