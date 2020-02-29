namespace Hackathon.Feature.Teams.Controllers
{
    using Hackathon.Feature.Teams.Models;
    using Hackathon.Feature.Teams.Repositories;
    using Hackathon.Feature.Teams.ViewModels;
    using Hackathon.Foundation.Content.Repositories;
    using Sitecore.Mvc.Controllers;
    using System;
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
        /// The recent items count
        /// </summary>
        private const int RecentItemsCount = 4;

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
            if (reference != null)
            {
                model.Teams = this.teamsRepository.GetAll(reference.TeamsFolder);
                model.Title = reference.TeamsTitle;
                return View(model);
            }

            return new EmptyResult();
        }

        public ActionResult Recent()
        {
            var reference = this.renderingRepository.GetDataSourceItem<ITeamsFolderReference>();
            if (reference == null)
            {
                reference = this.contextRepository.GetCurrentItem<ITeamsFolderReference>();
            }

            var model = new TeamList();
            if (reference != null)
            {
                model.Teams = this.teamsRepository.GetLatest(reference.TeamsFolder, RecentItemsCount);
                model.Title = reference.TeamsTitle;
                return View(model);
            }

            return new EmptyResult();
        }

        public ActionResult SubmissionPage()
        {
            var settings = this.teamsRepository.GetSubmitionSettings();
            var model = new SubmissionPage()
            {
                Enabled = settings != null && 
                    DateTime.Today >= settings.StartDate.Date &&
                    DateTime.Today <= settings.EndDate.Date
            };

            return View(model);
        }

        public ActionResult Statistics()
        {
            return new EmptyResult();
        }
    }
}
