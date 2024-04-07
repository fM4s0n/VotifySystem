using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Factory for FPTP-type election
/// </summary>
public static class ElectionFactory
{
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
                    ElectionId = Guid.NewGuid().ToString()
                };
            case ElectionVoteMechanism.STV:
                return new SingleTransferrableVoteElection
                {
                    Country = country,
                    ElectionId = Guid.NewGuid().ToString()
                };
            case ElectionVoteMechanism.Preferential:
                return new PreferentialElection
                {
                    Country = country,
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
                return new PreferentialElection
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
