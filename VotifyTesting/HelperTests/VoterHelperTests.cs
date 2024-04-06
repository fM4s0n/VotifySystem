using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifyTesting.HelperTests;

[TestClass]
public class VoterHelperTests
{
    [TestMethod]
    public void VoteMethodFriendlyNames_ShouldHaveCorrectValues()
    {
        // Arrange
        List<string> expected =
        [
            "Online",
            "Postal",
            "In Person"
        ];

        List<string> tests =
        [
            "Online",
            "Postal",
            "InPerson"
        ];

        // Act
        List<string> actual = [];

        foreach (var test in tests)        
            actual.Add(VoterHelper.GetVoteMethodFriendlyName(test));        

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
