using Glass.Mapper.Sc.Pipelines.AddMaps;
using Hackathon.Foundation.ORM.Extensions;

namespace Hackathon.Foundation.ORM.Mappings
{
    public class RegisterMappings : AddMapsPipeline  {
        public void Process(AddMapsPipelineArgs args)
        {
            args.MapsConfigFactory.AddFluentMaps("Hackathon.Foundation.ORM");
        }
    }
}
