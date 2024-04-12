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

        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        builder.SetElectionId()
            .SetCountry(Country.UK)
            .SetDates(start, end)
            .SetDescription("Test")
            .SetElectionAdministratorId("1");

        var election = builder.Build();

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

        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        builder.SetElectionId()
            .SetCountry(Country.UK)
            .SetDates(start, end)
            .SetDescription("Test")
            .SetElectionAdministratorId("1");

        var election = builder.Build();

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

        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        builder.SetElectionId()
            .SetCountry(Country.UK)
            .SetDates(start, end)
            .SetDescription("Test")
            .SetElectionAdministratorId("1");

        var election = builder.Build();

        // Act
        var result = election.GetElectionStatus();

        // Assert
        Assert.AreEqual(ElectionStatus.Completed, result);
    }
}
