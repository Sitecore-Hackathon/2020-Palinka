namespace Hackathon.Feature.Teams.Repositories
{
    using Hackathon.Feature.Teams.Models;
    using Hackathon.Foundation.Content.Repositories;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The teams repository
    /// </summary>
    public class TeamsRepository : ITeamsRepository
    {
        /// <summary>
        /// The content repository
        /// </summary>
        private readonly IContentRepository contentRepository;

        /// <summary>
        /// The settings path
        /// </summary>
        private const string SettingsPath = "/Global/Settings";

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="contentRepository">The content repository</param>
        public TeamsRepository(IContentRepository contentRepository)
        {
            this.contentRepository = contentRepository;
        }

        public IEnumerable<ITeam> GetAll(ITeamsFolder folder)
        {
            if (folder != null)
            {
                return folder.Teams.ToArray();
            }

            return new ITeam[0];
        }

        public IEnumerable<ITeam> GetLatest(ITeamsFolder folder, int count)
        {
            return GetAll(folder)
                .OrderByDescending(t => t.Created)
                .Take(count).ToArray();
        }

        public IEnumerable<ITeam> GetAll(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new System.ArgumentNullException(folderPath);
            }

            var folder = this.contentRepository.GetItem<ITeamsFolder>(new Glass.Mapper.Sc.GetItemByPathOptions(folderPath));
            return GetAll(folder);
        }

        public List<string> GetCountries(IEnumerable<ITeam> teams)
        {
            if (teams == null)
            {
                return new List<string>();
            }

            List<string> allCountries = new List<string>();
            foreach (var team in teams)
            {
                if (!string.IsNullOrEmpty(team.Country))
                {
                    var countries = team.Country.Split(',')
                        .Select(t => t.Trim()).ToArray();

                    if (countries.Any())
                    {
                        allCountries.AddRange(countries);
                    }
                }
            }

            return allCountries.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        public IEnumerable<ITeam> GetLatest(string folderPath, int count)
        {
            return GetAll(folderPath)
                .OrderByDescending(t => t.Created)
                .Take(count).ToArray();
        }

        public ISubmissionSettings GetSubmitionSettings()
        {
            string path = Sitecore.Context.Site.RootPath + SettingsPath;
            return this.contentRepository.GetItem<ISubmissionSettings>(new Glass.Mapper.Sc.GetItemByPathOptions(path));
        }

        public bool Exists(Guid parentId, string teamName)
        {
            var masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
            var parentItem = masterDb.GetItem(new ID(parentId));
            if (parentItem == null)
            {
                throw new InvalidOperationException("Target folder is not found!");
            }

            string itemName = ItemUtil.ProposeValidItemName(teamName);
            return parentItem.Children[itemName] != null;
        }

        public ITeam Create(Guid parentId, string teamName, string country, string email, List<TeamMember> members)
        {
            var masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
            var parentItem = masterDb.GetItem(new ID(parentId));
            if (parentItem == null)
            {
                throw new InvalidOperationException("Target folder is not found!");
            }

            var teamItem = CreateTeam(parentItem, teamName, country, email);

            int index = 1;
            foreach (var member in members)
            {
                if (member != null && !string.IsNullOrEmpty(member.FirstName))
                {
                    CreateTeamMember(teamItem, member, index);
                    index++;
                }
            }

            var model = contentRepository.GetItem<ITeam>(new Glass.Mapper.Sc.GetItemByItemOptions(teamItem));
            return model;
        }

        private Item CreateTeam(Item parent, string teamName, string country, string email)
        {
            string itemName = ItemUtil.ProposeValidItemName(teamName);
            var teamItem = parent.Add(itemName, new TemplateID(new ID(Constants.Team.TemplateId)));

            using (new EditContext(teamItem))
            {
                teamItem[new ID(Constants.Team.TeamNameFieldId)] = teamName;
                teamItem[new ID(Constants.Team.CountryFieldId)] = country;
                teamItem[new ID(Constants.Team.EmailFieldId)] = email;
            }

            return teamItem;
        }

        private void CreateTeamMember(Item parent, TeamMember member, int index)
        {
            string memberItemName = $"Team member {index}";
            var memberItem = parent.Add(memberItemName, new TemplateID(new ID(Constants.TeamMember.TemplateId)));

            using (new EditContext(memberItem))
            {
                memberItem[new ID(Constants.TeamMember.FirstName)] = member.FirstName;
                memberItem[new ID(Constants.TeamMember.LastName)] = member.LastName;
                memberItem[new ID(Constants.TeamMember.Twitter)] = member.Twitter;
                memberItem[new ID(Constants.TeamMember.LinkedIn)] = member.LinkedIn;
            }
        }

        public IEnumerable<ITeamsFolder> GetAllTeamsFolder()
        {
            string teamsFolderQuery = "/sitecore/content/Hackathon/Global/Teams/*";

            return this.contentRepository.GetItems<ITeamsFolder>(new Glass.Mapper.Sc.GetItemsByQueryOptions(new Glass.Mapper.Sc.Query(teamsFolderQuery)));
        }
    }
}
