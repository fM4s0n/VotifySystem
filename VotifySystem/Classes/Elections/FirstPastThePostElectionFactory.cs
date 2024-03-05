namespace VotifySystem.Classes.Elections;

/// <summary>
/// Factory for FPTP-type election
/// </summary>
internal class FirstPastThePostElectionFactory : IElectionFactory
{
    public Election CreateElection(string description, DateTime start, DateTime end)
    {
        FirstPastThePostElection election = new()
        {
            VoteMechanism = ElectionVoteMechanism.FPTP,
            ElectionId = Guid.NewGuid().ToString(),
            Description = description,
        };

        return election;
    }
}
