using Microsoft.EntityFrameworkCore;
using NSubstitute;
using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.BusinessLogic.Services.Implementations;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models;

namespace VotifyTesting.ServiceTests;

[TestClass]
public class CandidateServiceTests
{
    private CandidateService? _candidateService;
    private DbService? _dbService;
    private IFPTPElectionVoteService? _fptpElectionVoteService;

    [TestInitialize]
    public void SetUp()
    { 
        DbContextOptionsBuilder<VotifyDatabaseContext> builder = new();

        builder.EnableDetailedErrors();
        builder.EnableSensitiveDataLogging();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        VotifyDatabaseContext context = new(builder.Options);
        _dbService = new DbService(context);
        _fptpElectionVoteService = Substitute.For<IFPTPElectionVoteService>();

        _candidateService = new CandidateService(_dbService, _fptpElectionVoteService);      
    }

    [TestMethod]
    public void TestInsertCandidate()
    {
        // Arrange
        Candidate candidate = new() { Id = "1" };

        // Act
        _candidateService!.InsertCandidate(candidate);

        // Assert
        Assert.AreEqual(candidate, _dbService!.GetDatabaseContext().Candidates.First(c => c.Id == "1"));
           
    }

    [TestMethod]
    public void TestUpdateCandidate()
    {
        // Arrange
        Candidate candidate = new() { Id = "1" };
        _candidateService!.InsertCandidate(candidate);

        candidate.FirstName = "John";
        candidate.LastName = "Doe";

        // Act
        _candidateService!.UpdateCandidate(candidate);

        // Assert
        Assert.AreEqual(candidate, _dbService!.GetDatabaseContext().Candidates.First(c => c.Id == "1"));
    }

    [TestMethod]
    public void TestDeleteCandidate()
    {
        // Arrange
        Candidate candidate = new() { Id = "1" };
        _candidateService!.InsertCandidate(candidate);

        // Act
        _candidateService!.DeleteCandidate(candidate);

        // Assert
        Assert.IsFalse(_dbService!.GetDatabaseContext().Candidates.Any(c => c.Id == "1"));        
    }

    [TestMethod]
    public void TestGetAllCandidates()
    {
        // Arrange
        List<Candidate>? candidates = [new Candidate() { Id = "1" }, new Candidate() { Id = "2"}];
        _candidateService!.InsertCandidate(candidates[0]);
        _candidateService.InsertCandidate(candidates[1]);

        // Act
        List<Candidate>? result = _candidateService!.GetAllCandidates();

        // Assert
        CollectionAssert.AreEqual(candidates, result);
    }

    [TestMethod]
    public void TestGetCandidatesByElectionId()
    {
        // Arrange
        List<Candidate> candidates = [new Candidate { Id = "1", ElectionId = "1" }, new Candidate { Id = "2", ElectionId = "1" }];
        _candidateService!.InsertCandidate(candidates[0]);
        _candidateService.InsertCandidate(candidates[1]);

        // Act
        List<Candidate>? result = _candidateService!.GetCandidatesByElectionId("1");

        // Assert
        CollectionAssert.AreEqual(candidates, result);
    }

    [TestCleanup]
    public void TearDown()
    {
        _dbService = null;
        _candidateService = null;
        _fptpElectionVoteService = null;
    }
}
