namespace VotifySystem.Common.Classes.Elections;

internal  class ElectionResultFactory 
{
   
    public ElectionResult CalculateResult(Election election)
    {
        switch (election)
        {
            case FirstPastThePostElection fptpElection:
                return new FirstPastThePostElectionResult(fptpElection);
            case SingleTransferrableVoteElection stvElection:
                throw new NotImplementedException();
            default:
                throw new NotImplementedException();
        }
    }
}
