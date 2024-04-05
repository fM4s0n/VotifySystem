﻿using VotifySystem.Common.Classes;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.Classes.UIClasses;

namespace VotifySystem.Common.BusinessLogic.Helpers;

/// <summary>
/// Helper class for FPTP Election results
/// </summary>
internal static class FPTPResultsHelper
{
    /// <summary>
    /// Order candidates by the number of votes
    /// </summary>
    /// <param name="candidates">List of candidate</param>
    public static List<Candidate> OrderCandidatesByVotes(List<Candidate> candidates)
    { 
        candidates = candidates.OrderByDescending(c => c.VotesReceived).ToList();
    }

    [Obsolete]
    /// <summary>
    /// Checks for any ties in the candidate votes and fixes them by setting the position of the tied candidates to the same position
    /// </summary>
    /// <param name="gridItems">list of candidate grid items</param>
    /// <returns>same list with fixed Position properties</returns>
    public static List<CandidateDataGridItem> CheckAndFixTies(List<CandidateDataGridItem> gridItems)
    {
        foreach (CandidateDataGridItem item in gridItems)
        {
            List<CandidateDataGridItem> ties = gridItems.Where(gi => gi.Votes == item.Votes).ToList();

            if (ties.Count > 0)
            {
                // get the position of the first candidate in the tie list
                int tiedPosition = ties.First().Position;

                foreach (CandidateDataGridItem tie in ties)
                    gridItems[gridItems.IndexOf(tie)].Position = tiedPosition;
            }
        }

        return gridItems;
    }

    /// <summary>
    /// Overload of the CheckAndFixTies method for Candidate objects
    /// </summary>
    /// <param name="candidates"></param>
    /// <returns></returns>
    public static List<Candidate> CheckAndFixTies(List<Candidate> candidates)
    {
        foreach (Candidate cand in candidates)
        {
            List<Candidate> ties = candidates.Where(gi => gi.VotesReceived == cand.VotesReceived).ToList();

            if (ties.Count > 0)
            {
                // get the position of the first candidate in the tie list
                int tiedPosition = ties.First().ElectionPosition;

                foreach (Candidate tie in ties)
                    candidates[candidates.IndexOf(tie)].ElectionPosition = tiedPosition;
            }
        }

        return candidates;
    }

    /// <summary>
    /// Calculate the total votes received by each party in the election
    /// </summary>
    /// <param name="electionParties">List of parties in the election</param>
    /// <param name="candidates">List of all candidates in the election</param>
    /// <returns>Dictionary of party and list ordered by votes descending</returns>
    public static Dictionary<Party, int> CalculateTotalVotesPerParty(List<Party> electionParties, List<Candidate> candidates)
    {
        Dictionary<Party, int> partyTotalVotes = [];

        foreach (Party party in electionParties)
        {
            List<Candidate> partyCandidates = candidates.Where(c => c.PartyId == party.PartyId).ToList();

            int totalVotes = partyCandidates.Sum(c => c.VotesReceived);
            partyTotalVotes.Add(party, totalVotes);
        }

        return partyTotalVotes.OrderByDescending(p => p.Value)
                              .ToDictionary(p => p.Key, p => p.Value);
    }

    /// <summary>
    /// Calculate the number of constituencies won by each party
    /// </summary>
    /// <param name="parties">All parties involved in the election</param>
    /// <param name="candidates">All candidates in the election</param>
    /// <param name="constituencies">All constituencies in the election</param>
    /// <returns></returns>
    public static Dictionary<Party, List<Constituency>> CalculatePartyConstituencyWinsForElection(List<Party> parties, List<Candidate>candidates, List<Constituency> constituencies)
    {
        Dictionary<Party, List<Constituency>> partyConstituencyResults = [];

        // initialize the dictionary with every party
        foreach (Party party in parties) 
            partyConstituencyResults.Add(party, []);

        // calculate winner of each constituency
        foreach (Constituency constituency in constituencies)
        {
            // Calculate results for each constituency
            List<Candidate> conCandidates = candidates.Where(c => c.ConstituencyId == constituency.ConstituencyId).ToList();

            Party winnerParty = new();

            // order candidates by votes received
            conCandidates = OrderCandidatesByVotes(conCandidates);

            // check for ties and fix them
            conCandidates = CheckAndFixTies(conCandidates);

            // check if there's a tie for the win
            if (conCandidates.Count > 1 && conCandidates[0].VotesReceived == conCandidates[1].VotesReceived)
            {
                // get all tied candidates for the win
                List<Candidate> tiedCandidates = conCandidates.Where(c => c.VotesReceived == conCandidates[0].VotesReceived).ToList();

                // randomly select a winner from the tied candidates - simulates lottery done in real elections in UK
                Random random = new();
                int randomIndex = random.Next(0, tiedCandidates.Count);

                Candidate winnerCandidate = tiedCandidates[randomIndex];

                winnerParty = parties.First(p => p.PartyId == winnerCandidate.PartyId);
                partyConstituencyResults[winnerParty].Add(constituency);
            }
            else
            {
                // Determine the winner based on votes received
                winnerParty = parties.First(p => p.PartyId == conCandidates.First().PartyId);
                partyConstituencyResults[winnerParty].Add(constituency);
            }
                       
            partyConstituencyResults[winnerParty].Add(constituency);
        }

        return partyConstituencyResults;
    }
}