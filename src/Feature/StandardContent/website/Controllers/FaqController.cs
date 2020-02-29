namespace Hackathon.Feature.StandardContent.Controllers
{
    using Hackathon.Feature.StandardContent.Models;
    using Hackathon.Feature.StandardContent.ViewModels;
    using Hackathon.Foundation.Content.Repositories;
    using Sitecore.Mvc.Controllers;
    using System.Web.Mvc;

    /// <summary>
    /// The Frequently Asked Questions controller.
    /// </summary>
    public class FaqController : SitecoreController
    {
        /// <summary>
        /// The context repository.
        /// </summary>
        private readonly IContextRepository contextRepository;

        /// <summary>
        /// The content repository.
        /// </summary>
        private readonly IContentRepository contentRepository;

        /// <summary>
        /// The rendering repository.
        /// </summary>
        private readonly IRenderingRepository renderingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FaqController"/> class.
        /// </summary>
        /// <param name="contextRepository">Context repository.</param>
        /// <param name="contentRepository">Content repository.</param>
        /// <param name="renderingRepository">Rendering repository.</param>
        public FaqController(IContextRepository contextRepository, IContentRepository contentRepository, IRenderingRepository renderingRepository)
        {
            this.contextRepository = contextRepository;
            this.contentRepository = contentRepository;
            this.renderingRepository = renderingRepository;
        }

        /// <summary>
        /// Get All Frequently Asked Questions and Answers.
        /// </summary>
        /// <returns>Questions and answers.</returns>
        public ActionResult FaqList()
        {
            var faqFolder = renderingRepository.GetDataSourceItem<IFaqFolder>();

            FaqListViewModel faqListViewModel = new FaqListViewModel()
            {
                Faqs = faqFolder.Faqs
            };

            return View(faqListViewModel);
        }
    }
}
