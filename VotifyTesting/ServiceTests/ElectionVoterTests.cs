using Microsoft.EntityFrameworkCore;
using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Services.Implementations;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models.Elections;

namespace VotifyTesting.ServiceTests;

[TestClass]
public class ElectionVoterTests
{
    DbService? _dbService;
    ElectionVoterService? _electionVoterService;

    [TestInitialize]
    public void SetUp()
    {
        DbContextOptionsBuilder<VotifyDatabaseContext> builder = new();

        builder.EnableDetailedErrors();
        builder.EnableSensitiveDataLogging();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        VotifyDatabaseContext context = new(builder.Options);
        _dbService = new DbService(context);

        _electionVoterService = new ElectionVoterService(_dbService);
    }

    [TestMethod]
    public void TestInsertElectionVoter()
    {
        // Arrange
        ElectionVoter electionVoter = new() { ElectionId = "1", VoterId = "1" };

        // Act
        _electionVoterService!.InsertElectionVoter(electionVoter);

        // Assert
        Assert.AreEqual(electionVoter, _dbService!.GetDatabaseContext().ElectionVoters.First(ev => ev.ElectionId == "1" && ev.VoterId == "1"));
    }

    [TestMethod]
    public void TestUpdateElectionVoter()
    {
        // Arrange
        ElectionVoter electionVoter = new() { ElectionId = "1", VoterId = "1" };
        _electionVoterService!.InsertElectionVoter(electionVoter);

        electionVoter.HasVoted = true;

        // Act
        _electionVoterService!.UpdateElectionVoter(electionVoter);

        // Assert
        Assert.AreEqual(electionVoter, _dbService!.GetDatabaseContext().ElectionVoters.First(ev => ev.ElectionId == "1" && ev.VoterId == "1"));
    }

    [TestMethod]
    public void TestDeleteElectionVoter()
    {
        // Arrange
        ElectionVoter electionVoter = new() { ElectionId = "1", VoterId = "1" };
        _electionVoterService!.InsertElectionVoter(electionVoter);

        // Act
        _electionVoterService!.DeleteElectionVoter(electionVoter);

        // Assert
        Assert.IsNull(_dbService!.GetDatabaseContext().ElectionVoters.FirstOrDefault(ev => ev.ElectionId == "1" && ev.VoterId == "1"));
    }

    [TestMethod]
    public void TestGetElectionVoter()
    {
        // Arrange
        ElectionVoter electionVoter = new() { ElectionId = "1", VoterId = "1" };
        _electionVoterService!.InsertElectionVoter(electionVoter);

        // Act
        ElectionVoter? result = _electionVoterService!.GetElectionVoter("1", "1");

        // Assert
        Assert.AreEqual(electionVoter, result);
    }

    [TestMethod]
    public void TestGetElectionVotersByElectionId()
    {
        // Arrange
        List<ElectionVoter> expected = [];

        ElectionVoter electionVoter1 = new() { ElectionId = "1", VoterId = "1" };
        expected.Add(electionVoter1);

        ElectionVoter electionVoter2 = new() { ElectionId = "1", VoterId = "2" };
        expected.Add(electionVoter2);

        ElectionVoter electionVoter3 = new() { ElectionId = "1", VoterId = "3" };
        expected.Add(electionVoter3);

        _electionVoterService!.InsertElectionVoter(electionVoter1);
        _electionVoterService!.InsertElectionVoter(electionVoter2);
        _electionVoterService!.InsertElectionVoter(electionVoter3);

        // Act
        List<ElectionVoter>? result = _electionVoterService!.GetElectionVotersByElectionId("1");

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestGetElectionVotersByVoterId()
    {
        // Arrange
        List<ElectionVoter> expected = [];

        ElectionVoter electionVoter1 = new() { ElectionId = "1", VoterId = "1" };
        expected.Add(electionVoter1);

        ElectionVoter electionVoter2 = new() { ElectionId = "2", VoterId = "1" };
        expected.Add(electionVoter2);

        ElectionVoter electionVoter3 = new() { ElectionId = "3", VoterId = "1" };
        expected.Add(electionVoter3);

        _electionVoterService!.InsertElectionVoter(electionVoter1);
        _electionVoterService!.InsertElectionVoter(electionVoter2);
        _electionVoterService!.InsertElectionVoter(electionVoter3);

        // Act
        List<ElectionVoter>? result = _electionVoterService!.GetElectionVotersByVoterId("1");

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
