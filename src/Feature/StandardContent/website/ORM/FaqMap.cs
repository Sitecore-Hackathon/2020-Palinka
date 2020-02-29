namespace Hackathon.Feature.StandardContent.ORM
{
    using Glass.Mapper.Sc.Maps;
    using Hackathon.Feature.StandardContent.Models;

    public class FaqMap : SitecoreGlassMap<IFaq>
    {
        private const string TemplateId = "{826DF816-63A5-4BD8-ABBE-69AFC9E2C660}";
        private const string QuestionFieldId = "{32D90729-EEAD-44D0-9068-D064223D4CCC}";
        private const string AnswerFieldId = "{826742A0-8023-4244-8466-06CE6691D6E6}";


        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(TemplateId);
                config.Field(f => f.Question).FieldId(QuestionFieldId);
                config.Field(f => f.Answer).FieldId(AnswerFieldId);
            });
        }
    }
}
