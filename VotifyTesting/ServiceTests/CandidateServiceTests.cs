using NSubstitute;
using System.Linq.Expressions;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.BusinessLogic.Services.Implementations;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models;

namespace VotifyTesting.ServiceTests;

[TestClass]
public class CandidateServiceTests
{
    CandidateService? _candidateService;
    IDbService? _dbService;
    IFPTPElectionVoteService? _fptpElectionVoteService;

    [TestInitialize]
    public void SetUp()
    {
        // substitute the IDbService
        _dbService = Substitute.For<IDbService>();
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
        _dbService!.Received(1).InsertEntity(candidate);        
    }

    [TestMethod]
    public void TestUpdateCandidate()
    {
        // Arrange
        Candidate candidate = new() { Id = "1" };

        // Act
        _candidateService!.UpdateCandidate(candidate);

        // Assert
        _dbService!.Received().UpdateEntity(candidate);
    }

    [TestMethod]
    public void TestDeleteCandidate()
    {
        // Arrange
        Candidate candidate = new() { Id = "1" };

        // Act
        _candidateService!.DeleteCandidate(candidate);

        // Assert
        _dbService!.Received().DeleteEntity(candidate);
    }

    [TestMethod]
    public void TestGetAllCandidates()
    {
        // Arrange
        List<Candidate> candidates = [new Candidate() { Id = "1" }, new Candidate() { Id = "2"}];
        _dbService!.GetDatabaseContext().Candidates.ToList().Returns(candidates);

        // Act
        List<Candidate>? result = _candidateService!.GetAllCandidates();

        // Assert
        Assert.AreEqual(candidates, result);
    }

    [TestMethod]
    public void TestGetCandidatesByElectionId()
    {
        // Arrange
        List<Candidate> candidates = new List<Candidate> { new Candidate { Id = "1", ElectionId = "1" }, new Candidate { Id = "2", ElectionId = "1" } };
        _dbService!.GetDatabaseContext().Candidates.Where(Arg.Any<Expression<Func<Candidate, bool>>>()).ToList().Returns(candidates);

        // Act
        List<Candidate>? result = _candidateService!.GetCandidatesByElectionId("1");

        // Assert
        Assert.AreEqual(candidates, result);
    }
}
