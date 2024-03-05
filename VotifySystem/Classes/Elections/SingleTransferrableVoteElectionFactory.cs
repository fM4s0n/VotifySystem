namespace VotifySystem.Classes.Elections;

/// <summary>
/// Factory for STV-type election
/// </summary>
internal class SingleTransferrableVoteElectionFactory : IElectionFactory
{
    public Election CreateElection(string description, DateTime startDate, DateTime endDate)
    {
        SingleTransferrableVoteElection election = new()
        {
            VoteMechanism = ElectionVoteMechanism.STV,
            ElectionId = Guid.NewGuid().ToString(),
            Description = description,
            StartDate = startDate,
            EndDate = endDate
        };

        return election;
    }
}
