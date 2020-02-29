namespace Hackathon.Feature.Teams.Repositories
{
    using Hackathon.Feature.Teams.Models;
    using Hackathon.Foundation.Content.Repositories;
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

        public IEnumerable<ITeam> GetLatest(string folderPath, int count)
        {
            return GetAll(folderPath)
                .OrderByDescending(t => t.Created)
                .Take(count).ToArray();
        }

        public ITeam Add(string name, string country)
        {
            return null;
        }

        public IEnumerable<ITeamsFolder> GetAllTeamsFolder()
        {
            string teamsFolderQuery = "/sitecore/content/Hackathon/Global/Teams/*";

            return this.contentRepository.GetItems<ITeamsFolder>(new Glass.Mapper.Sc.GetItemsByQueryOptions(new Glass.Mapper.Sc.Query(teamsFolderQuery)));
        }
    }
}
