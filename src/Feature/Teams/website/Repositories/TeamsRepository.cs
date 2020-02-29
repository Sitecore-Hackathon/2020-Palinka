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

        public IEnumerable<ITeam> GetAll(string folderPath)
        {
            var folder = this.contentRepository.GetItem<ITeamsFolder>(new Glass.Mapper.Sc.GetItemByPathOptions(folderPath));
            if (folder != null)
            {
                return folder.Teams.ToArray();
            }

            return new ITeam[0];
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
    }
}
