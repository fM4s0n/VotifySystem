namespace VotifySystem.Classes.Elections;

/// <summary>
/// Factory for FPTP-type election
/// </summary>
internal class FirstPastThePostElectionFactory : IElectionFactory
{
    public Election CreateElection(string description, DateTime startDate, DateTime endDate)
    {
        FirstPastThePostElection election = new()
        {
            VoteMechanism = ElectionVoteMechanism.FPTP,
            ElectionId = Guid.NewGuid().ToString(),
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
        };

        return election;
    }
}
