using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotifySystem.Common.Classes;

namespace VotifyTests.ClassTests;

[TestClass]
internal class UserTests
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
