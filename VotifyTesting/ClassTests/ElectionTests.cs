using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifyTesting.ClassTests;

[TestClass]
public class ElectionTests
{
    [TestMethod]
    public void TestGetElectionStatus_NotStarted()
    {
        // Arrange
        DateTime start = DateTime.Now.AddDays(1);
        DateTime end = start.AddDays(2);
        var election = ElectionFactory.CreateElection(ElectionVoteMechanism.FPTP, Country.UK, "Test", start, end, "1");

        // Act
        var result = election.GetElectionStatus();

        // Assert
        Assert.AreEqual(ElectionStatus.NotStarted, result);
    }

    [TestMethod]
    public void TestGetElectionStatus_InProgress()
    {
        // Arrange
        DateTime start = DateTime.Now.AddDays(-1);
        DateTime end = start.AddDays(2);
        var election = ElectionFactory.CreateElection(ElectionVoteMechanism.FPTP, Country.UK, "Test", start, end, "1");

        // Act
        var result = election.GetElectionStatus();

        // Assert
        Assert.AreEqual(ElectionStatus.InProgress, result);
    }

    [TestMethod]
    public void TestGetElectionStatus_Completed()
    {
        // Arrange
        DateTime start = DateTime.Now.AddDays(-3);
        DateTime end = start.AddDays(1);
        var election = ElectionFactory.CreateElection(ElectionVoteMechanism.FPTP, Country.UK, "Test", start, end, "1");

        // Act
        var result = election.GetElectionStatus();

        // Assert
        Assert.AreEqual(ElectionStatus.Completed, result);
    }
}
