namespace Hackathon.Feature.Teams.Controllers
{
    using Hackathon.Feature.Teams.Models;
    using Hackathon.Feature.Teams.Repositories;
    using Hackathon.Feature.Teams.ViewModels;
    using Hackathon.Foundation.Content.Repositories;
    using Hackathon.Foundation.ORM.Models;
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
        /// The teams repository
        /// </summary>
        private readonly ITeamsRepository teamsRepository;

        /// <summary>
        /// The rendering repository
        /// </summary>
        private readonly IRenderingRepository renderingRepository;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public TeamsController(IContextRepository contextRepository, IRenderingRepository renderingRepository, ITeamsRepository teamsRepository)
        {
            this.contextRepository = contextRepository;
            this.renderingRepository = renderingRepository;
            this.teamsRepository = teamsRepository;
        }

        public ActionResult List()
        {
            var reference = this.renderingRepository.GetDataSourceItem<ITeamsFolderReference>();
            if (reference == null)
            {
                reference = this.contextRepository.GetCurrentItem<ITeamsFolderReference>();
            }

            var model = new TeamList();
            if(reference != null)
            {
                model.Teams = this.teamsRepository.GetAll(reference.TeamsFolder);
                model.Title = reference.TeamsTitle;
            }

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

        public ActionResult CurrentWinners()
        {
            var model = this.contextRepository.GetCurrentItem<IWinners>();
            return View(model);
        }

        public ActionResult PreviousWinners()
        {
            var model = this.contextRepository.GetCurrentItem<IWinners>();
            return View(model);
        }
    }
}
