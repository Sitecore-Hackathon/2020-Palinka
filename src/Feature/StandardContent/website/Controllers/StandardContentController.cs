namespace Hackathon.Feature.StandardContent.Controllers
{
    using Glass.Mapper.Sc.Web.Mvc;
    using Hackathon.Feature.StandardContent.Models;
    using Hackathon.Foundation.Content.Repositories;
    using Sitecore.Mvc.Controllers;
    using System.Web.Mvc;

    public class StandardContentController : SitecoreController
    {
        private readonly IContextRepository contextRepository;

        private readonly IContentRepository contentRepository;

        public StandardContentController(IContextRepository contextRepository, IContentRepository contentRepository)
        {
            this.contextRepository = contextRepository;
            this.contentRepository = contentRepository;
        }

        public ActionResult Text()
        {
            var model = contextRepository.GetCurrentItem<IText>();
            return View(model);
        }

        public ActionResult Image()
        {
            var model = contextRepository.GetCurrentItem<IImage>();
            return View(model);
        }
    }
}
