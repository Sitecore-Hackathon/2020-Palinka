namespace Hackathon.Feature.Teams.Controllers
{
    using Hackathon.Feature.Teams.Repositories;
    using Hackathon.Feature.Teams.ViewModels;
    using Hackathon.Foundation.Content.Repositories;
    using Sitecore.Mvc.Controllers;
    using System.Web.Mvc;

    /// <summary>
    /// The Teams controller
    /// </summary>
    public class TeamsController : SitecoreController
    {
        /// <summary>
        /// The context repository
        /// </summary>
        private readonly IContextRepository contextRepository;

        /// <summary>
        /// The content repository
        /// </summary>
        private readonly IContentRepository contentRepository;

        /// <summary>
        /// The teams repository
        /// </summary>
        private readonly ITeamsRepository teamsRepository;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="contextRepository">The context repository</param>
        /// <param name="contentRepository">The content repository</param>
        public TeamsController(IContextRepository contextRepository, IContentRepository contentRepository, ITeamsRepository teamsRepository)
        {
            this.contextRepository = contextRepository;
            this.contentRepository = contentRepository;
            this.teamsRepository = teamsRepository;
        }

        public ActionResult List()
        {
            var model = new TeamList();

            return View(model);
        }

        public ActionResult Recent()
        {
            return new EmptyResult();
        }

        public ActionResult Statistics()
        {
            return new EmptyResult();
        }
    }
}
