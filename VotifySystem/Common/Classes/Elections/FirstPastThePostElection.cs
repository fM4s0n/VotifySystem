namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// 
/// </summary>
public class FirstPastThePostElection : Election
{
    public readonly ElectionVoteMechanism VoteMechanism = ElectionVoteMechanism.FPTP;

    public FirstPastThePostElection() { }
}
    