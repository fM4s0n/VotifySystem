using VotifySystem.Common.Models;

namespace VotifyTesting.ClassTests;

[TestClass]
public class LoginCodeTests
{
    [TestMethod]
    public void TestGetValidity_ValidTime_NotUsed()
    {
        // Arrange
        LoginCode loginCode = new()
        {
            GeneratedDate = DateTime.Now.AddMinutes(-20),
            Used = false
        };

        // Act
        var result = loginCode.GetValidity();

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestGetValidity_InvalidTime_NotUsed()
    {
        // Arrange
        LoginCode loginCode = new()
        {
            GeneratedDate = DateTime.Now.AddMinutes(-40),
            Used = false
        };

        // Act
        var result = loginCode.GetValidity();

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestGetValidity_ValidTime_Used()
    {
        // Arrange
        LoginCode loginCode = new()
        {
            GeneratedDate = DateTime.Now.AddMinutes(-20),
            Used = true
        };

        // Act
        var result = loginCode.GetValidity();

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestGetValidity_InvalidTime_Used()
    {
        // Arrange
        LoginCode loginCode = new()
        {
            GeneratedDate = DateTime.Now.AddMinutes(-40),
            Used = true
        };

        // Act
        var result = loginCode.GetValidity();

        // Assert
        Assert.IsFalse(result);
    }
}
