namespace VotifySystem.Common.Classes.UIClasses;

/// <summary>
/// Class to hold data for the candidate data grid
/// </summary>
public class CandidateDataGridItem(int position, string name, string party, int votes)
{
    public int Position { get; set; } = position;
    public string Name { get; set; } = name;
    public string Party { get; set; } = party;
    public int Votes { get; set; } = votes;
}
