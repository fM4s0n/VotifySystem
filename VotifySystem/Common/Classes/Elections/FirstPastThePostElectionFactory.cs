namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// Factory for FPTP-type election
/// </summary>
internal class FirstPastThePostElectionFactory : IElectionFactory
{
    public Election CreateElection(string description, DateTime startDate, DateTime endDate)
    {
        return new FirstPastThePostElection
        {
            VoteMechanism = ElectionVoteMechanism.FPTP,
            ElectionId = Guid.NewGuid().ToString(),
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
        };
    }
}
