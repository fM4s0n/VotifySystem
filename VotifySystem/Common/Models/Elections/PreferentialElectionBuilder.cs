using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Preferential election builder
/// </summary>
public class PreferentialElectionBuilder : IElectionBuilder
{
    private readonly Election _election;

    public PreferentialElectionBuilder()
    {
        _election = new PreferentialVoteElection();
    }

    //<inheritdoc/>
    public Election Build()
    {
        return _election;
    }

    //<inheritdoc/>
    public IElectionBuilder SetCountry(Country country)
    {
        _election.Country = country;
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
    public IElectionBuilder SetDescription(string description)
    {
        _election.Description = description;
        return this;
    }

    //<inheritdoc/>
    public IElectionBuilder SetElectionAdministratorId(string userId)
    {
        _election.ElectionAdministratorId = userId;
        return this;
    }

    //<inheritdoc/>
    public IElectionBuilder SetElectionId()
    {
        _election.ElectionId = Guid.NewGuid().ToString();
        return this;
    }
}
