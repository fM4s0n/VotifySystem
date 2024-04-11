using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifyTesting.FactoryTests;

[TestClass]
public  class ElectionFactoryTests
{
    [TestMethod]
    public void TestCreateFPTPElection()
    {
        // Arrange
        var voteMechanism = ElectionVoteMechanism.FPTP;
        var country = Country.UK;
        
        // Act
        var election = ElectionFactory.CreateElection(voteMechanism, country);
        
        // Assert
        Assert.IsNotNull(election);
        Assert.AreEqual(voteMechanism, election.VoteMechanism);
        Assert.AreEqual(country, election.Country);
        Assert.IsNotNull(election.ElectionId);
        Assert.IsInstanceOfType(election, typeof(FirstPastThePostElection));
    }

    [TestMethod]
    public void TestCreateSTVElection()
    {
        // Arrange
        var voteMechanism = ElectionVoteMechanism.STV;
        var country = Country.UK;
        
        // Act
        var election = ElectionFactory.CreateElection(voteMechanism, country);
        
        // Assert
        Assert.IsNotNull(election);
        Assert.AreEqual(voteMechanism, election.VoteMechanism);
        Assert.AreEqual(country, election.Country);
        Assert.IsNotNull(election.ElectionId);
        Assert.IsInstanceOfType(election, typeof(SingleTransferrableVoteElection));
    }

    [TestMethod]
    public void TestCreatePreferentialElection()
    {
        // Arrange
        var voteMechanism = ElectionVoteMechanism.Preferential;
        var country = Country.UK;
        
        // Act
        var election = ElectionFactory.CreateElection(voteMechanism, country);
        
        // Assert
        Assert.IsNotNull(election);
        Assert.AreEqual(voteMechanism, election.VoteMechanism);
        Assert.AreEqual(country, election.Country);
        Assert.IsNotNull(election.ElectionId);
        Assert.IsInstanceOfType(election, typeof(PreferentialVoteElection));
    }
}
