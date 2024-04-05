namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// 
/// </summary>
internal abstract class ElectionResult 
{
    public Election Election { get; set; }
    public List<Candidate> Candidates { get; set; }
    public Dictionary<Candidate, Party> CandidatePartiesDictionary { get; set; }
}
