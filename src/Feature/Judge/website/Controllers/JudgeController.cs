namespace Hackathon.Feature.Judge.Controllers
{
    using Hackathon.Feature.Judge.Models;
    using Hackathon.Feature.Judge.ViewModels;
    using Hackathon.Foundation.Content.Repositories;
    using Sitecore.Mvc.Controllers;
    using System.Web.Mvc;

    public class JudgeController : SitecoreController
    {
        private readonly IContextRepository contextRepository;

        private readonly IContentRepository contentRepository;

        private readonly IRenderingRepository renderingRepository;


        public JudgeController(IContextRepository contextRepository, IContentRepository contentRepository, IRenderingRepository renderingRepository)
        {
            this.contextRepository = contextRepository;
            this.contentRepository = contentRepository;
            this.renderingRepository = renderingRepository;
        }

        public ActionResult JudgeList()
        {
            var eventPage = renderingRepository.GetRenderingItem<IEventPage>();

            JudgeListViewModel judgeListViewModel = new JudgeListViewModel()
            {
                CommunityJudges = eventPage.CommunityJudges,
                SitecoreJudges = eventPage.SitecoreJudges
            };                

            return View(judgeListViewModel);
        }
    }
}
