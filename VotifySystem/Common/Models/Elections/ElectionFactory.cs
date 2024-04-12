using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Factory for FPTP-type election
/// </summary>
public static class ElectionFactory
{
    /// <summary>
    /// Create a new election builder
    /// Factory of builders used to allow for different types of elections to be created
    /// implementing build mehtods in different ways depending on the type of election
    /// </summary>
    /// <param name="voteMechanism">The vote mechanism of the election</param>
    /// <returns>ElectionBuilder For the selected election type</returns>
    public static IElectionBuilder CreateBuilder(ElectionVoteMechanism voteMechanism)
    {
        switch (voteMechanism)
        {
            case ElectionVoteMechanism.FPTP:
                return new FPTPElectionBuilder();
            case ElectionVoteMechanism.STV:
                throw new NotImplementedException();
            case ElectionVoteMechanism.Preferential:
                return new PreferentialElectionBuilder();
            default:
                throw new NotImplementedException();
        }
    }
}
