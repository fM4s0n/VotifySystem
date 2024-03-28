using Microsoft.VisualBasic.ApplicationServices;

namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// Factory for FPTP-type election
/// </summary>
public static class ElectionFactory
{
    public static Election CreateElection(ElectionVoteMechanism voteMechanism)
    {
        return voteMechanism switch
        {
            ElectionVoteMechanism.FPTP => new FirstPastThePostElection
            {
                ElectionId = Guid.NewGuid().ToString()
            },
            ElectionVoteMechanism.STV => new SingleTransferrableVoteElection
            {
                ElectionId = Guid.NewGuid().ToString()
            }
        };
    }

    public static Election CreateElection(ElectionVoteMechanism voteMechanism, string description, DateTime startDate, DateTime endDate, User user)
    {
        return voteMechanism switch
        {
            ElectionVoteMechanism.FPTP => new FirstPastThePostElection
            {
                ElectionId = Guid.NewGuid().ToString(),
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                ElectionAdministrator = user
            },
            ElectionVoteMechanism.STV => new SingleTransferrableVoteElection
            {
                ElectionId = Guid.NewGuid().ToString(),
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                ElectionAdministrator = user
            }
        };           
    }
}
