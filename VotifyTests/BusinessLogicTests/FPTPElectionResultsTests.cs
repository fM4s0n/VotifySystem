using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Classes;

namespace VotifyTests.BusinessLogicTests;

internal class FPTPElectionResultsTests
{
    [TestMethod]
    internal void TestOrderCandidatesByVotes()
    {
        //Arrange
        List<Candidate> candidates =
        [
            new Candidate { Id = "1" },
            new Candidate { Id = "2" },
            new Candidate { Id = "3"}
        ];

        //Act
        foreach (Candidate candidate in candidates)
        {
            Random random = new();
            candidate.AddVotes(random.Next(1, 100));
        }

        //Assert
        List<Candidate> orderedCandidates = FPTPResultsHelper.OrderCandidatesByVotes(candidates);

        foreach (Candidate candidate in orderedCandidates)
        {
            int index = orderedCandidates.IndexOf(candidate);
            Assert.AreEqual(index + 1, candidate.ElectionPosition);            
        }

        List<int> orderedCandidatesVotes = orderedCandidates.Select(c => c.VotesReceived).ToList();

        //check if the list is ordered by votes descending
        Assert.IsTrue(orderedCandidatesVotes.SequenceEqual(orderedCandidatesVotes.OrderByDescending(v => v)));
    }
}
