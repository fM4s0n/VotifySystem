using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.Models.Votes;

namespace VotifyTesting.FactoryTests;

[TestClass]
public class VoteFactoryTests
{
    [TestMethod]
    public void TestCreateFPTPVote()
    {
        // Arrange
        string electionId = "1";
        ElectionVoteMechanism voteMechanism = ElectionVoteMechanism.FPTP;

        // Act
        Vote vote = VoteFactory.CreateVote(electionId, voteMechanism);

        // Assert
        Assert.IsNotNull(vote);
        Assert.AreEqual(electionId, vote.ElectionId);
        Assert.AreEqual(voteMechanism, vote.ElectionVoteMechanism);
        Assert.IsInstanceOfType(vote, typeof(FPTPElectionVote));
    }

    [TestMethod]
    public void TestCreatePreferentialVote()
    {
        // Arrange
        string electionId = "1";
        ElectionVoteMechanism voteMechanism = ElectionVoteMechanism.Preferential;

        // Act
        Vote vote = VoteFactory.CreateVote(electionId, voteMechanism);

        // Assert
        Assert.IsNotNull(vote);
        Assert.AreEqual(electionId, vote.ElectionId);
        Assert.AreEqual(voteMechanism, vote.ElectionVoteMechanism);
        Assert.IsInstanceOfType(vote, typeof(PreferentialElectionVote));
    }

    [TestMethod]
    public void TestCreateSTVVote()
    {
        // Arrange
        string electionId = "1";
        ElectionVoteMechanism voteMechanism = ElectionVoteMechanism.STV;

        // Act and Assert
        Assert.ThrowsException<NotImplementedException>(() => VoteFactory.CreateVote(electionId, voteMechanism));
    }
}
