namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// Factory for FPTP-type election
/// </summary>
internal static class ElectionFactory
{
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
