using Hackathon.Feature.JudgeApplication.Models;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Hackathon.Feature.JudgeApplication.Controllers
{
    /// <summary>
    /// Judge application controller
    /// </summary>
    /// <seealso cref="Sitecore.Mvc.Controllers.SitecoreController" />
    [System.Web.Mvc.Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class JudgeApplicationController : SitecoreController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JudgeApplicationController"/> class.
        /// </summary>
        public JudgeApplicationController()
        {
        }

        /// <summary>
        /// Teamses this instance.
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult Teams()
        {
            using (new DatabaseSwitcher(Factory.GetDatabase("master")))
            {
                var teams = Sitecore.Context.Database.SelectItems(this.TeamsQuery)
                    .Select(t => new TeamModel
                    {
                        ID = t.ID.ToString(),
                        TeamName = t["Team Name"],
                        Country = t["Country"],
                        GitHubLink = t["GitHub Link"],
                        Reviewed = GetReviewed(t)
                    }).ToList();

                return Json(teams, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Details the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Team Detail</returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult Detail(string id)
        {
            using (new DatabaseSwitcher(Factory.GetDatabase("master")))
            {
                var team = Sitecore.Context.Database.GetItem(new ID(id));
                var teamModel = new TeamModel
                {
                    ID = team.ID.ToString(),
                    TeamName = team["Team Name"],
                    Country = team["Country"],
                    GitHubLink = team["GitHub Link"],
                    Reviewed = GetReviewed(team),
                    Member = team.Children.Where(t => t.TemplateName.Equals("Team Member")).
                    Select(p => new TeamMember
                    {
                        Name = $"{p["First Name"]} {p["Last Name"]}"
                    }).ToList()
                };

                if (teamModel.Reviewed)
                {
                    var judgeItem = team.Children["Judges"].Children[Sitecore.Context.User.LocalName];

                    teamModel.Point = judgeItem["Point"];
                    teamModel.Comment = judgeItem["Comments"];
                }

                return Json(teamModel, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Sends the point.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Action Result</returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult SendPoint([FromBody]PointsRequest request)
        {
            using (new DatabaseSwitcher(Factory.GetDatabase("master")))
            {
                var team = Sitecore.Context.Database.GetItem(new ID(request.TeamId));
                var judgeValuationTemplate = Sitecore.Context.Database.GetItem(new ID("{4CC5BB60-689D-46F1-83CB-348EA5DA3950}"));
                var folderTemplate = Sitecore.Context.Database.GetItem(new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}"));

                Sitecore.Data.Items.Item judgesFolder = null;
                if (team.Children["Judges"] == null)
                {
                    judgesFolder = team.Add("Judges", new TemplateItem(folderTemplate));
                }
                else
                {
                    judgesFolder = team.Children["Judges"];
                }

                var judge = judgesFolder.Add(Sitecore.Context.User.LocalName, new TemplateItem(judgeValuationTemplate));

                using (new EditContext(judge))
                {
                    judge["Point"] = request.Point;
                    judge["Comments"] = request.Comment;
                }

                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Gets the reviewed.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns>Returns if the team's submission has been reviewed</returns>
        public bool GetReviewed(Sitecore.Data.Items.Item team)
        {
            var userName = Sitecore.Context.User.LocalName;

            return team.Axes.GetDescendants().Any(t => t.Name.StartsWith(userName, StringComparison.OrdinalIgnoreCase));
        }
    }
}