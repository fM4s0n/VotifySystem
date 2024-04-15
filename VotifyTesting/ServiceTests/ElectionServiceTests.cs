using Microsoft.EntityFrameworkCore;
using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services.Implementations;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models.Elections;

namespace VotifyTesting.ServiceTests;

[TestClass]
public class ElectionServiceTests
{
    ElectionService? _electionService;
    DbService? _dbService;

    [TestInitialize]
    public void Initialize()
    {
        DbContextOptionsBuilder<VotifyDatabaseContext> builder = new();

        builder.EnableDetailedErrors();
        builder.EnableSensitiveDataLogging();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        VotifyDatabaseContext context = new(builder.Options);

        // Initialize the database context
        _dbService = new (context);
        _electionService = new ElectionService(_dbService);
    }

    [TestMethod]
    public void TestInsertElection()
    {
        // Arrange
        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        Election election = builder.Build();

        // Act
        _electionService!.InsertElection(election);

        // Assert
        Assert.AreEqual(election, _dbService!.GetDatabaseContext().Elections.First());
    }

    [TestMethod]
    public void TestUpdateElection()
    {
        // Arrange
        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        Election election = builder.Build();
        _electionService!.InsertElection(election);

        election.Description = "Test Election";
        election.Description = "This is a test election";

        // Act
        _electionService.UpdateElection(election);

        // Assert
        Assert.AreEqual(election, _dbService!.GetDatabaseContext().Elections.First());
    }

    [TestMethod]
    public void TestDeleteElection()
    {
        // Arrange
        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        Election election = builder.Build();
        _electionService!.InsertElection(election);

        // Act
        _electionService.DeleteElection(election);

        // Assert
        Assert.IsFalse(_dbService!.GetDatabaseContext().Elections.Contains(election));
    }

    [TestMethod]
    public void TestGetAllElections()
    {
        // Arrange
        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        Election election = builder.Build();
        _electionService!.InsertElection(election);

        // Act
        var elections = _electionService.GetAllElections();

        // Assert
        Assert.IsTrue(elections!.Contains(election));
    }

    [TestMethod]
    public void TestGetElectionsByCountry()
    {
        // Arrange
        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        builder.SetCountry(Country.UK);
        Election election = builder.Build();
        _electionService!.InsertElection(election);

        // Act
        var elections = _electionService.GetElectionsByCountry(election.Country);

        // Assert
        Assert.IsTrue(elections!.Contains(election));
    }
}
