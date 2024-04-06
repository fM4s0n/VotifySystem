using Microsoft.AspNetCore.Identity;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Controls;

namespace VotifyTesting.ServiceTests;

[TestClass]
public class UserServiceTests
{
    [TestMethod]
    public void TestGetCurrentUserAndLogInUser()
    {
        // Arrange
        UserService userService = new();
        Voter voter = new() { Id = "1" };
        userService.LogInUser(voter, LoginMode.InPerson);

        // Act
        User? result = userService.GetCurrentUser();

        // Assert
        Assert.AreEqual(voter, result);
    }

    [TestMethod]
    public void TestGetCurrentUserLevel()
    {
        // Arrange
        UserService userService = new();
        Voter voter = new() { Id = "1", UserLevel = UserLevel.Voter };
        userService.LogInUser(voter, LoginMode.InPerson);

        // Act
        UserLevel result = userService.GetCurrentUserLevel();

        // Assert
        Assert.AreEqual(UserLevel.Voter, result);
    }

    [TestMethod]
    public void TestLogOutUser()
    {
        // Arrange
        UserService userService = new();
        Voter voter = new() { Id = "1" };
        userService.LogInUser(voter, LoginMode.InPerson);

        // Act
        userService.LogOutUser();
        User? result = userService.GetCurrentUser();

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void TestLogInEvent()
    {
        // Arrange
        UserService userService = new();
        Voter voter = new() { Id = "1" };
        userService.LogInUser(voter, LoginMode.InPerson);
        bool eventFired = false;
        userService.LogInEvent += (sender, e) => eventFired = true;

        // Act
        userService.LogInUser(voter, LoginMode.InPerson);

        // Assert
        Assert.IsTrue(eventFired);
    }

    [TestMethod]
    public void TestLogOutEvent()
    {
        // Arrange
        UserService userService = new();
        Voter voter = new() { Id = "1" };
        userService.LogInUser(voter, LoginMode.InPerson);
        bool eventFired = false;
        userService.LogOutEvent += (sender, e) => eventFired = true;

        // Act
        userService.LogOutUser();

        // Assert
        Assert.IsTrue(eventFired);
    }

    [TestMethod]
    public void TestHashPassword()
    {
        // Arrange
        UserService userService = new();
        string plainTextPassword1 = "password";
        string plainTextPassword2 = "password";

        // Act
        string hashedPassword1 = userService.HashPassword(new Voter(), plainTextPassword1);
        string hashedPassword2 = userService.HashPassword(new Voter(), plainTextPassword2);

        // Assert
        Assert.AreNotEqual(plainTextPassword1, hashedPassword1);
        Assert.AreNotEqual(plainTextPassword2, hashedPassword2);
        Assert.AreNotEqual(hashedPassword1, hashedPassword2);
    }

    /// <summary>
    /// This tests VerifyPassword()
    /// </summary>
    [TestMethod]
    public void TestVerifyPasswordValidDetails()
    {
        // Arrange
        UserService userService = new();
        string hashedPassword = userService.HashPassword(new Voter(), "password");
        Voter voter = new() { Id = "1", Password = hashedPassword };

        // Act
        PasswordVerificationResult result = userService.VerifyPassword("password", voter);

        // Assert
        Assert.AreEqual(PasswordVerificationResult.Success, result);
    }

    [TestMethod]
    public void TestVerifyPasswordInvalidDetails()
    {
        // Arrange
        UserService userService = new();
        string hashedPassword = userService.HashPassword(new Voter(), "password");
        Voter voter = new() { Id = "1", Password = hashedPassword };

        // Act
        PasswordVerificationResult result = userService.VerifyPassword("WrongPassword", voter);

        // Assert
        Assert.AreEqual(PasswordVerificationResult.Failed, result);
    }

    [TestMethod]
    public void TestGenerateLoginCode()
    {
        // Arrange
        UserService userService = new();
        Voter voter = new() { Id = "1" };
        userService.LogInUser(voter, LoginMode.InPerson);

        // Act
        LoginCode result = userService.GenerateLoginCode();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Code.Length);
        Assert.AreEqual(voter.Id, result.UserId);
        Assert.IsTrue(result.GeneratedDate < DateTime.Now);
        Assert.IsFalse(result.Used);
        Assert.IsTrue(result.Valid);
    }

    [TestMethod]
    public void TestGetLoginMode()
    {
        // Arrange
        UserService userService = new();
        Voter voter = new() { Id = "1" };
        userService.LogInUser(voter, LoginMode.InPerson);

        // Act
        LoginMode result = userService.GetLoginMode();

        // Assert
        Assert.AreEqual(LoginMode.InPerson, result);
    }

    [TestMethod]
    public void TestGetAppCultureCode()
    {
        // Arrange
        UserService userService = new();
        Voter voter = new() { Id = "1", Country = Country.UK };
        string expected = "en-GB";

        // Act
        userService.LogInUser(voter, LoginMode.InPerson);
        string result = userService.GetAppCultureCode();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestSetAppCultureCode()
    {
        // Arrange
        UserService userService = new();
        Voter voter = new() { Id = "1", Country = Country.UK };
        string expected = "en-GB";

        // Act
        userService.LogInUser(voter, LoginMode.InPerson);
        string result = userService.GetAppCultureCode();

        // Assert
        Assert.AreEqual(expected, result);
    }
}
