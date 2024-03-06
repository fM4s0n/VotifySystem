namespace VotifySystem.Classes;

/// <summary>
/// Candidate Class
/// Does not need to login as if they want to vote, they should be a voter.
/// Administrator will create the election wiht relevent candidtates
/// </summary>
public class Candidate : Person
{
    public string CandidateId { get; set; } = string.Empty;
    public string Constituency {  get; set; } = string.Empty;
}
