using System.Collections.Generic;
using Hackathon.Feature.Teams.Models;

namespace Hackathon.Feature.Teams.Repositories
{
    public interface ITeamsRepository
    {
        ITeam Add(string name, string country);
        IEnumerable<ITeam> GetAll(ITeamsFolder folder);
        IEnumerable<ITeam> GetAll(string folderPath);
        IEnumerable<ITeam> GetLatest(string folderPath, int count);
        IEnumerable<ITeam> GetLatest(ITeamsFolder folder, int count);
    }
}