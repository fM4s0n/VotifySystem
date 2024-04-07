namespace VotifySystem.Common.Models.Elections;

public class PreferentialElection : Election
{
    public readonly ElectionVoteMechanism VoteMechanism = ElectionVoteMechanism.Preferential;

    public PreferentialElection()
    {
    }
}
