using Sitecore.Pipelines.RenderField;

namespace Hackathon.Feature.ShowTitles.Pipelines.RenderField
{
    public class ShowTitleWhenBlank
    {
        public void Process(RenderFieldArgs args)
        {
            args.RenderParameters["show-title-when-blank"] = "true";
        }
    }
}
