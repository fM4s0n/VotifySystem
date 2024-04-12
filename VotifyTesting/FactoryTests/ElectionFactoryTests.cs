using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifyTesting.FactoryTests;

[TestClass]
public  class ElectionFactoryTests
{
    [TestMethod]
    public void TestBuildFPTPElection()
    {
        // Arrange
        var voteMechanism = ElectionVoteMechanism.FPTP;
        var country = Country.UK;
        DateTime start = DateTime.Now;
        DateTime end = DateTime.Now.AddDays(1);
        string adminId = Guid.NewGuid().ToString();
        string description = "Test Election";
        
        // Act
        var builder = ElectionFactory.CreateBuilder(voteMechanism);
        builder.SetElectionId()
            .SetCountry(country)
            .SetDates(start, end)
            .SetDescription(description)
            .SetElectionAdministratorId(adminId);

        var election = builder.Build();
        
        // Assert
        Assert.IsNotNull(election);
        Assert.AreEqual(voteMechanism, election.VoteMechanism);
        Assert.AreEqual(country, election.Country);
        Assert.AreEqual(start, election.StartDate);
        Assert.AreEqual(end, election.EndDate);
        Assert.AreEqual(adminId, election.ElectionAdministratorId);
        Assert.AreEqual(description, election.Description);
        Assert.IsNotNull(election.ElectionId);
        Assert.IsInstanceOfType(election, typeof(FirstPastThePostElection));
    }

    [TestMethod]
    public void TestCreateSTVElection()
    {
        // Arrange
        var voteMechanism = ElectionVoteMechanism.STV;

        // Act & Assert
        Assert.ThrowsException<NotImplementedException>(() => ElectionFactory.CreateBuilder(voteMechanism));
    }

    [TestMethod]
    public void TestBuildPreferentialElection()
    {
        // Arrange
        ElectionVoteMechanism voteMechanism = ElectionVoteMechanism.Preferential;
        Country country = Country.UK;
        string description = "Test Election";
        DateTime start = DateTime.Now;
        DateTime end = DateTime.Now.AddDays(1);
        string adminId = Guid.NewGuid().ToString();
        
        // Act
        var builder = ElectionFactory.CreateBuilder(voteMechanism);
        builder.SetElectionId()
            .SetDescription(description)
            .SetCountry(country)
            .SetDates(start, end)
            .SetElectionAdministratorId(adminId);

        var election = builder.Build();
        
        // Assert
        Assert.IsNotNull(election);
        Assert.AreEqual(voteMechanism, election.VoteMechanism);
        Assert.AreEqual(country, election.Country);
        Assert.IsNotNull(election.ElectionId);
        Assert.AreEqual(description, election.Description);
        Assert.AreEqual(start, election.StartDate);
        Assert.AreEqual(end, election.EndDate);
        Assert.AreEqual(adminId, election.ElectionAdministratorId);
        Assert.IsInstanceOfType(election, typeof(PreferentialVoteElection));
    }

    [TestMethod]
    public void TestInvalidElectionType()
    {
        // Arrange
        var voteMechanism = (ElectionVoteMechanism) 3;

        // Act & Assert
        Assert.ThrowsException<NotImplementedException>(() => ElectionFactory.CreateBuilder(voteMechanism));
    }
}
