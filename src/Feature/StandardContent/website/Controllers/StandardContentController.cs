namespace Hackathon.Feature.StandardContent.Controllers
{
    using Hackathon.Feature.StandardContent.Models;
    using Hackathon.Feature.StandardContent.ViewModels;
    using Hackathon.Foundation.Content.Repositories;
    using Hackathon.Foundation.ORM.Models;
    using Sitecore.Mvc.Controllers;
    using System.Web.Mvc;

    public class StandardContentController : SitecoreController
    {
        private readonly IContextRepository contextRepository;

        private readonly IRenderingRepository renderingRepository;

        public StandardContentController(IContextRepository contextRepository, IRenderingRepository renderingRepository)
        {
            this.contextRepository = contextRepository;
            this.renderingRepository = renderingRepository;
        }

        public ActionResult Text()
        {
            var model = renderingRepository.GetRenderingItem<IText>();
            return View(model);
        }

        public ActionResult Image()
        {
            var model = contextRepository.GetCurrentItem<IImage>();
            return View(model);
        }

        public ActionResult CategoryList()
        {
            var model = contextRepository.GetCurrentItem<ICategories>();
            return View(model);
        }

        public ActionResult PrizeList()
        {
            var model = contextRepository.GetCurrentItem<IPrizes>();
            return View(model);
        }

        public ActionResult TestimonialSlider()
        {
            var model = renderingRepository.GetRenderingItem<ITestimonialSource>();
            return View(model);
        }

        public ActionResult Sponsors()
        {
            var sponsorFolder = renderingRepository.GetDataSourceItem<ISponsors>();

            SponsorsViewModel sponsorsViewModel = new SponsorsViewModel()
            {
                Sponsors = sponsorFolder.Sponsors
            };

            return View(sponsorsViewModel);
        }
    }
}