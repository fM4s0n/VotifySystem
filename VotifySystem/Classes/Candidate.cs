namespace VotifySystem.Classes;

/// <summary>
/// Candidate Class
/// </summary>
public class Candidate(string firstName, string lastName, VoteMethod voteMethod) : Voter(firstName, lastName, voteMethod)
{
    public string CandidateId { get; set; } = string.Empty;
    public string Constituency {  get; set; } = string.Empty;
}
