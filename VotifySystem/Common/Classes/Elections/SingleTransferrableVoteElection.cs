namespace VotifySystem.Common.Classes.Elections;

/// <summary>
/// Single Transferrable Vote Election
/// </summary>
public class SingleTransferrableVoteElection : Election
{
   public readonly ElectionVoteMechanism VoteMechanism = ElectionVoteMechanism.STV;
}
