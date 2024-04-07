using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.UIClasses;

namespace VotifyTesting.HelperTests;

[TestClass]
public class FPTPResultsHelperTests
{
    [TestMethod]
    public void TestOrderCandidatesByVotes()
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

    [TestMethod]
    public void TestGenericCheckAndFixTies()
    {
        //Arrange
        List<GenericTieFixCheckItem> items =
        [
            new GenericTieFixCheckItem("1",1,10),
            new GenericTieFixCheckItem("2", 2, 10),
            new GenericTieFixCheckItem("3",3,5), 
            new GenericTieFixCheckItem("4",4,4),
            new GenericTieFixCheckItem("5",5,4)
        ];

        //Act
        List<GenericTieFixCheckItem> fixedItems = FPTPResultsHelper.GenericCheckAndFixTies(items);

        //Assert
        Assert.AreEqual(fixedItems[0].Position, 1);
        Assert.AreEqual(fixedItems[1].Position, 1);
        Assert.AreEqual(fixedItems[2].Position, 3);
        Assert.AreEqual(fixedItems[3].Position, 4);
        Assert.AreEqual(fixedItems[4].Position, 4);

        Assert.AreEqual(fixedItems[0].Value, 10);
        Assert.AreEqual(fixedItems[1].Value, 10);
        Assert.AreEqual(fixedItems[2].Value, 5);
        Assert.AreEqual(fixedItems[3].Value, 4);
        Assert.AreEqual(fixedItems[4].Value, 4);

        Assert.AreEqual(fixedItems[0].Key, "1");
        Assert.AreEqual(fixedItems[1].Key, "2");
        Assert.AreEqual(fixedItems[2].Key, "3");
        Assert.AreEqual(fixedItems[3].Key, "4");
        Assert.AreEqual(fixedItems[4].Key, "5");
    }

    [TestMethod]
    public void TestCalculateTotalVotesPerParty()
    {
        // Arrange
        List<Party> electionParties =
        [
            new Party { PartyId = "1" },
            new Party { PartyId = "2" },
            new Party { PartyId = "3" }
        ];

        List<Candidate> candidates =
        [
            new Candidate { Id = "1", PartyId = "1"},
            new Candidate { Id = "2", PartyId = "1" },
            new Candidate { Id = "3", PartyId = "2" },
            new Candidate { Id = "4", PartyId = "2" },
            new Candidate { Id = "5", PartyId = "3" }
        ];

        candidates[0].AddVotes(10);
        candidates[1].AddVotes(20);
        candidates[2].AddVotes(30);
        candidates[3].AddVotes(40);
        candidates[4].AddVotes(50);

        // Act
        Dictionary<Party, int> partyTotalVotes = FPTPResultsHelper.CalculateTotalVotesPerParty(electionParties, candidates);

        // Assert
        Assert.AreEqual(30, partyTotalVotes[electionParties[0]]);
        Assert.AreEqual(70, partyTotalVotes[electionParties[1]]);
        Assert.AreEqual(50, partyTotalVotes[electionParties[2]]);
    }

    [TestMethod]
    public void TestCalculatePartyConstituencyWinsForElection() {

        // Arrange
        List<Constituency> constituencies =
        [
            new Constituency { ConstituencyId = "1" },
            new Constituency { ConstituencyId = "2" }
        ];

        List<Party> parties =
        [
            new Party { PartyId = "1" },
            new Party { PartyId = "2" },
        ];

        List<Candidate> candidates =
        [
            //part 2 wins
            new Candidate { Id = "1", PartyId = "1", ConstituencyId = "1" }, // 10 votes
            new Candidate { Id = "2", PartyId = "2", ConstituencyId = "1" }, // 20 votes

            // part 2 wins
            new Candidate { Id = "3", PartyId = "1", ConstituencyId = "2" }, // 10 votes
            new Candidate { Id = "4", PartyId = "2", ConstituencyId = "2" }, // 10 votes
            new Candidate { Id = "5", PartyId = "2", ConstituencyId = "2" }  // 5 votes
        ];

        candidates[0].AddVotes(10);
        candidates[1].AddVotes(20);
        candidates[2].AddVotes(10);
        candidates[3].AddVotes(10);
        candidates[4].AddVotes(5);

        // Act
        Dictionary<Party, List<Constituency>> partyConstituencyWins = FPTPResultsHelper.CalculatePartyConstituencyWinsForElection(parties, candidates, constituencies);

        // Assert
        Assert.AreEqual(0, partyConstituencyWins[parties[0]].Count);
        Assert.AreEqual(2, partyConstituencyWins[parties[1]].Count);
    }

    [TestMethod]
    public void TestAddOrdinal()
    {
        // Arrange
        List<int> numbers = [1, 2, 3, 4, 10, 13, 111, 255];

        List<string> results = [];

        List<string> expected = ["1st", "2nd", "3rd", "4th", "10th", "13th", "111th", "255th"];

        // Act
        foreach (int number in numbers)        
            results.Add(FPTPResultsHelper.AddOrdinal(number));        

        // Assert
        Assert.IsTrue(results.SequenceEqual(expected));
    }
}