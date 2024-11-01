﻿using VotifySystem.Common.Models;
using VotifySystem.Common.Models.UI;

namespace VotifySystem.Common.BusinessLogic.Helpers;

/// <summary>
/// Helper class for FPTP Election results
/// TODO: Refactor this whole helper to be OOP - 
/// should be a factory to produce separate ElectionResult Class based on the election type
/// </summary>
public static class FPTPResultsHelper
{
    /// <summary>
    /// Order candidates by the number of votes
    /// sets position of each candidate in the list
    /// does not handle ties
    /// </summary>
    /// <param name="candidates">List of candidate ordered by votes with Position property set</param>
    public static List<Candidate> OrderCandidatesByVotes(List<Candidate> candidates)
    { 
        candidates = candidates.OrderByDescending(c => c.VotesReceived).ToList();

        for (int i = 0; i < candidates.Count; i++)
            candidates[i].ElectionPosition = i + 1;

        return candidates;
    }

    [Obsolete("Now superseded by GenericCheckAndFixTies()")]
    /// <summary>
    /// Checks for any ties in the candidate votes and fixes them by setting the position of the tied candidates to the same position
    /// </summary>
    /// <param name="gridItems">list of candidate grid items</param>
    /// <returns>same list with fixed Position properties</returns>
    /// THIS HAS BEEN LEFT IN FOR DEMONSTRATION PURPOSES  - NOT REFERENCED BY ANY OTHER CODE
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
    /// Generic method to check for ties in list
    /// </summary>
    /// <param name="items">list of GenericTieFixCheckItem</param>
    /// <returns>list of GenericTieFixCheckItem with fixed positions taking into account any ties</returns>
    public static List<GenericTieFixCheckItem> GenericCheckAndFixTies(List<GenericTieFixCheckItem> items)
    {
        items = items.OrderByDescending(i => i.Value).ToList();

        foreach (GenericTieFixCheckItem checkItem in items)
        {
            List<GenericTieFixCheckItem> ties = items.Where(ci => ci.Value == checkItem.Value).ToList();

            if (ties.Count > 0)
            {
                // get the position of the first candidate in the tie list
                int tiedPosition = ties.First().Position;

                foreach (GenericTieFixCheckItem tie in ties)
                    items[items.IndexOf(tie)].Position = tiedPosition;
            }
        }

        return items;
    }

    [Obsolete("Now superseeded by GenericCheckAndFixTies()")]
    /// <summary>
    /// Overload of the CheckAndFixTies method for Candidate objects
    /// </summary>
    /// <param name="candidates"></param>
    /// <returns></returns>
    /// THIS HAS BEEN LEFT IN FOR DEMONSTRATION PURPOSES  - NOT REFERENCED BY ANY OTHER CODE
    public static List<Candidate> CheckAndFixTies(List<Candidate> candidates)
    {
        foreach (Candidate ca in candidates)
        {
            List<Candidate> ties = candidates.Where(gi => gi.VotesReceived == ca.VotesReceived).ToList();

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
    /// <returns>Dictionary of each party and list containing each constituency they won</returns>
    public static Dictionary<Party, List<Constituency>> CalculatePartyConstituencyWinsForElection(List<Party> parties, List<Candidate>candidates, List<Constituency> constituencies)
    {
        Dictionary<Party, List<Constituency>> partyConstituencyResults = [];

        // initialize the dictionary with every party
        foreach (Party party in parties) 
            partyConstituencyResults.Add(party, []);

        // calculate winner of each constituency
        foreach (Constituency constituency in constituencies)
        {
            List<GenericTieFixCheckItem> tieFixCheckItems = [];

            // Calculate results for each constituency
            List<Candidate> conCandidates = candidates.Where(c => c.ConstituencyId == constituency.ConstituencyId).ToList();

            Party winnerParty = new();

            // order candidates by votes received
            conCandidates = OrderCandidatesByVotes(conCandidates);

            foreach (Candidate candidate in conCandidates)
                tieFixCheckItems.Add(new(candidate.Id, candidate.ElectionPosition, candidate.VotesReceived));

            // check for ties and fix them
            tieFixCheckItems = GenericCheckAndFixTies(tieFixCheckItems);

            // update the positions in the candidates
            foreach (Candidate can in conCandidates)
                can.ElectionPosition = tieFixCheckItems.First(t => t.Key == can.Id).Position;

            // check if there's a tie for the win
            if (conCandidates.Count > 1 && conCandidates[0].VotesReceived == conCandidates[1].VotesReceived)
            {
                // get all tied candidates for the win
                List<Candidate> tiedCandidates = conCandidates.Where(c => c.VotesReceived == conCandidates[0].VotesReceived).ToList();

                // randomly select a winner from the tied candidates - simulates lottery done in real elections in UK
                Random random = new();
                int randomIndex = random.Next(1, tiedCandidates.Count);

                Candidate winnerCandidate = tiedCandidates[randomIndex];

                winnerParty = parties.First(p => p.PartyId == winnerCandidate.PartyId);
            }
            else
            {
                // Determine the winner based on votes received
                winnerParty = parties.First(p => p.PartyId == conCandidates.First().PartyId);
            }

            partyConstituencyResults[winnerParty].Add(constituency);
        }

        return partyConstituencyResults;
    }

    /// <summary>
    /// code snippet from StackOverflow users 'samjudson' and 'Wai Ha Lee'
    /// https://stackoverflow.com/questions/20156
    /// Method to add ordinal suffix to a number
    /// </summary>
    /// <param name="num">int to received ordinal suffix</param>
    /// <returns>string with Ordinal suffix appended to number</returns>
    public static string AddOrdinal(int num)
    {
        if (num <= 0) return num.ToString();

        // These could be switch cases, but I think this is more readable
        switch (num % 100)
        {
            case 11:
            case 12:
            case 13:
                return num + "th";
        }

        switch (num % 10)
        {
            case 1:
                return num + "st";
            case 2:
                return num + "nd";
            case 3:
                return num + "rd";
            default:
                return num + "th";
        }
    }
}
