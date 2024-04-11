using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Preferential election builder
/// </summary>
public class PreferentialElectionBuilder : IElectionBuilder
{
    //<inheritdoc/>
    public Election Build()
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public IElectionBuilder SetCountry(Country country)
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public IElectionBuilder SetDates(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public IElectionBuilder SetDescription(string description)
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public IElectionBuilder SetElectionAdministratorId(string userId)
    {
        throw new NotImplementedException();
    }

    //<inheritdoc/>
    public IElectionBuilder SetElectionId()
    {
        throw new NotImplementedException();
    }
}
