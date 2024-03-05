namespace VotifySystem.Classes;
internal class Election
{
    public string Description { get; set; } = string.Empty;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public List<Candidate> Candidates { get; set; }

}
