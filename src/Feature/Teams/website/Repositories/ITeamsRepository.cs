using System;
using System.Collections.Generic;
using Hackathon.Feature.Teams.Models;

namespace Hackathon.Feature.Teams.Repositories
{
    public interface ITeamsRepository
    {
        ITeam Create(Guid targetId, string teamName, string country, string email, List<TeamMember> members);
        IEnumerable<ITeam> GetAll(ITeamsFolder folder);
        IEnumerable<ITeam> GetAll(string folderPath);
        IEnumerable<ITeam> GetLatest(string folderPath, int count);
        IEnumerable<ITeam> GetLatest(ITeamsFolder folder, int count);

        ISubmissionSettings GetSubmitionSettings();

        List<string> GetCountries(IEnumerable<ITeam> teams);
    }
}