using Glass.Mapper.Sc.Pipelines.AddMaps;
using Hackathon.Foundation.ORM.Extensions;

namespace Hackathon.Feature.Hero.ORM
{
    public class RegisterMappings : AddMapsPipeline  {
        public void Process(AddMapsPipelineArgs args)
        {
            args.MapsConfigFactory.AddFluentMaps("Hackathon.Feature.Hero");
        }
    }
}
