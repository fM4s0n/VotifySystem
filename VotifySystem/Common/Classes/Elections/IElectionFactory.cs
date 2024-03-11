namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// 
/// </summary>
internal interface IElectionFactory
{
    Election CreateElection(string description, DateTime startDate, DateTime endDate);
}