namespace VotifySystem.Classes;

/// <summary>
/// Candidate Class
/// </summary>
public class Candidate : Person
{
    public string CandidateId { get; set; } = string.Empty;
    public string Constituency {  get; set; } = string.Empty;
}
