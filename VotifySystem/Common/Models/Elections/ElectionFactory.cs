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

    /// <summary>
    /// Basic creation of an election
    /// used for creating new election for frmCreateElection where the id is needed early
    /// </summary>
    public static Election CreateElection(ElectionVoteMechanism voteMechanism, Country country)
    {
        switch (voteMechanism)
        {
            case ElectionVoteMechanism.FPTP:
                return new FirstPastThePostElection
                {
                    Country = country,
                    VoteMechanism = ElectionVoteMechanism.FPTP,
                    ElectionId = Guid.NewGuid().ToString()
                };
            case ElectionVoteMechanism.STV:
                return new SingleTransferrableVoteElection
                {
                    Country = country,
                    VoteMechanism = ElectionVoteMechanism.STV,
                    ElectionId = Guid.NewGuid().ToString()
                };
            case ElectionVoteMechanism.Preferential:
                return new PreferentialVoteElection
                {
                    Country = country,
                    VoteMechanism = ElectionVoteMechanism.Preferential,
                    ElectionId = Guid.NewGuid().ToString()
                };
            default:
                throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Creates with all parameters specified
    /// Used for data seeding
    /// </summary>
    public static Election CreateElection(ElectionVoteMechanism voteMechanism, Country country, string description, DateTime startDate, DateTime endDate, string userId)
    {
        switch (voteMechanism)
        {
            case ElectionVoteMechanism.FPTP:
                return new FirstPastThePostElection
                {
                    Country = country,
                    ElectionId = Guid.NewGuid().ToString(),
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    ElectionAdministratorId = userId
                };
            case ElectionVoteMechanism.STV:
                return new SingleTransferrableVoteElection
                {
                    Country = country,
                    ElectionId = Guid.NewGuid().ToString(),
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    ElectionAdministratorId = userId
                };
            case ElectionVoteMechanism.Preferential:
                return new PreferentialVoteElection
                {
                    Country = country,
                    ElectionId = Guid.NewGuid().ToString(),
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    ElectionAdministratorId = userId
                };
            default:
                throw new NotImplementedException();
        }
    }
}
