namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// 
/// </summary>
public class FirstPastThePostElection : Election
{
    public readonly ElectionVoteMechanism VoteMechanism = ElectionVoteMechanism.FPTP;

    public FirstPastThePostElection() { }
}
    