namespace VotifySystem.Common.Models.UI;

/// <summary>
/// Class to hold data for the candidate data grid
/// </summary>
public class CandidateDataGridItem(string candidateId, int position, string name, string party, int votes)
{
    public string CandidateId { get; set; } = candidateId;
    public int Position { get; set; } = position;
    public string Name { get; set; } = name;
    public string PartyId { get; set; } = party;
    public int Votes { get; set; } = votes;
}
