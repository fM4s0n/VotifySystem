using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// Factory for FPTP-type election
/// </summary>
public static class ElectionFactory
{
    public static Election CreateElection(ElectionVoteMechanism voteMechanism, Country country)
    {
        return voteMechanism switch
        {
            ElectionVoteMechanism.FPTP => new FirstPastThePostElection
            {
                ElectionId = Guid.NewGuid().ToString(),
                Country = country
            },
            ElectionVoteMechanism.STV => new SingleTransferrableVoteElection
            {
                ElectionId = Guid.NewGuid().ToString(),
                Country = country
            },
            _ => throw new NotImplementedException()
        };
    }

    public static Election CreateElection(ElectionVoteMechanism voteMechanism, Country country, string description, DateTime startDate, DateTime endDate, string userId)
    {
        return voteMechanism switch
        {
            ElectionVoteMechanism.FPTP => new FirstPastThePostElection
            {
                Country = country,
                ElectionId = Guid.NewGuid().ToString(),
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                ElectionAdministratorId = userId
            },
            ElectionVoteMechanism.STV => new SingleTransferrableVoteElection
            {
                Country = country,
                ElectionId = Guid.NewGuid().ToString(),
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                ElectionAdministratorId = userId
            },
            _ => throw new NotImplementedException()
        };           
    }
}
