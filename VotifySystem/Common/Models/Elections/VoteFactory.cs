namespace VotifySystem.Common.Models.Elections;

/// <summary>
/// Vote factory class to create vote depending on the election vote mechanism.
/// </summary>
public class VoteFactory
{    
    public static Vote CreateVote(string electionId, ElectionVoteMechanism voteMechanism)
    {
        switch (voteMechanism)
        {
            case ElectionVoteMechanism.FPTP:
                return new FPTPElectionVote(electionId);
            case ElectionVoteMechanism.Preferential:
                return new PreferentialElectionVote(electionId);
            case ElectionVoteMechanism.STV:
                throw new NotImplementedException("STV vote mechanism not implemented yet");
            default:
                throw new ArgumentException("Invalid vote mechanism");
        }
    }
}
