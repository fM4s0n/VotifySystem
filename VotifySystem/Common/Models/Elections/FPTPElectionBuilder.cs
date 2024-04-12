using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Builder for creating an election
/// </summary>
public class FPTPElectionBuilder : IElectionBuilder
{
    private readonly Election _election;

    /// <summary>
    /// Constructor for the ElectionBuilder
    /// </summary>
    public FPTPElectionBuilder()
    {
        _election = new FirstPastThePostElection() { VoteMechanism = ElectionVoteMechanism.FPTP };
    }

    //<inheritdoc/>
    public IElectionBuilder SetElectionId()
    {
        _election.ElectionId = Guid.NewGuid().ToString();
        return this;
    }

    //<inheritdoc/>
    public IElectionBuilder SetDescription(string description)
    {
        _election.Description = description;
        return this;
    }

    //<inheritdoc/>
    public IElectionBuilder SetDates(DateTime startDate, DateTime endDate)
    {
        _election.StartDate = startDate;
        _election.EndDate = endDate;
        return this;
    }

    //<inheritdoc/>
    public IElectionBuilder SetElectionAdministratorId(string userId)
    {
        _election.ElectionAdministratorId = userId;
        return this;
    }

    //<inheritdoc/>
    public IElectionBuilder SetCountry(Country country)
    {
        _election.Country = country;
        return this;
    }

    //<inheritdoc/>
    public Election Build()
    {
        return _election;
    }
}