namespace VotifySystem.Classes.Elections;

/// <summary>
/// Factory for STV-type election
/// </summary>
internal class SingleTransferrableVoteElectionFactory : IElectionFactory
{
    public Election CreateElection(string description, DateTime start, DateTime end)
    {
        SingleTransferrableVoteElection election = new()
        {
            VoteMechanism = ElectionVoteMechanism.STV,
            ElectionId = Guid.NewGuid().ToString(),
            Description = description,
        };

        return election;
    }
}
