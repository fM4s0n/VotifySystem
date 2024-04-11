using VotifySystem.Common.Models;

namespace VotifyTesting.ClassTests;

[TestClass]
public class PersonTests
{
    [TestMethod]
    public void TestFullName()
    {
        //Arrange
        string expected = "John Doe";

        Voter voter = new()
        {
            //Act
            FirstName = "John",
            LastName = "Doe"
        };

        //Assert
        Assert.AreEqual(expected, voter.FullName);
    }
}