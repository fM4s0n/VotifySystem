using VotifySystem.Common.Classes;

namespace VotifyTesting.ClassTests;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void TestFullName()
    {
        //Arrange
        Voter voter = new();

        //Act
        voter.FirstName = "John";
        voter.LastName = "Doe";

        //Assert
        string expected = "John Doe";
        Assert.AreEqual(expected, voter.FullName);
    }
}