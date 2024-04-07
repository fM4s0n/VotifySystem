using Microsoft.AspNetCore.Identity;
using NSubstitute;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Controls;

namespace VotifyTesting.ServiceTests;

[TestClass]
public class UserServiceTests
{
    UserService? _userService;
    [TestInitialize]
    public void SetUp()
    {
        // substitute the IDbService
        IDbService dbService = Substitute.For<IDbService>();
        _userService = new UserService(dbService, false);
    }

    [TestMethod]
    public void TestGetCurrentUserAndLogInUser()
    {
        // Arrange
        Voter voter = new() { Id = "1" };
        _userService!.LogInUser(voter, LoginMode.InPerson);

        // Act
        User? result = _userService.GetCurrentUser();

        // Assert
        Assert.AreEqual(voter, result);
    }

    [TestMethod]
    public void TestGetCurrentUserLevel()
    {
        // Arrange
        Voter voter = new() { Id = "1", UserLevel = UserLevel.Voter };
        _userService!.LogInUser(voter, LoginMode.InPerson);

        // Act
        UserLevel result = _userService.GetCurrentUserLevel();

        // Assert
        Assert.AreEqual(UserLevel.Voter, result);
    }

    [TestMethod]
    public void TestLogOutUser()
    {
        // Arrange
        Voter voter = new() { Id = "1" };
        _userService!.LogInUser(voter, LoginMode.InPerson);

        // Act
        _userService.LogOutUser();
        User? result = _userService.GetCurrentUser();

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void TestLogInEvent()
    {
        // Arrange
        Voter voter = new() { Id = "1" };
        _userService!.LogInUser(voter, LoginMode.InPerson);
        bool eventFired = false;
        _userService.LogInEvent += (sender, e) => eventFired = true;

        // Act
        _userService.LogInUser(voter, LoginMode.InPerson);

        // Assert
        Assert.IsTrue(eventFired);
    }

    [TestMethod]
    public void TestLogOutEvent()
    {
        // Arrange
        Voter voter = new() { Id = "1" };
        _userService!.LogInUser(voter, LoginMode.InPerson);
        bool eventFired = false;
        _userService.LogOutEvent += (sender, e) => eventFired = true;

        // Act
        _userService.LogOutUser();

        // Assert
        Assert.IsTrue(eventFired);
    }

    [TestMethod]
    public void TestHashPassword()
    {
        // Arrange
        string plainTextPassword1 = "password";
        string plainTextPassword2 = "password";

        // Act
        string hashedPassword1 = _userService!.HashPassword(new Voter(), plainTextPassword1);
        string hashedPassword2 = _userService.HashPassword(new Voter(), plainTextPassword2);

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
        string hashedPassword = _userService!.HashPassword(new Voter(), "password");
        Voter voter = new() { Id = "1", Password = hashedPassword };

        // Act
        PasswordVerificationResult result = _userService.VerifyPassword("password", voter);

        // Assert
        Assert.AreEqual(PasswordVerificationResult.Success, result);
    }

    [TestMethod]
    public void TestVerifyPasswordInvalidDetails()
    {
        // Arrange
        string hashedPassword = _userService!.HashPassword(new Voter(), "password");
        Voter voter = new() { Id = "1", Password = hashedPassword };

        // Act
        PasswordVerificationResult result = _userService.VerifyPassword("WrongPassword", voter);

        // Assert
        Assert.AreEqual(PasswordVerificationResult.Failed, result);
    }

    [TestMethod]
    public void TestGenerateLoginCode()
    {
        // Arrange
        Voter voter = new() { Id = "1" };
        _userService!.LogInUser(voter, LoginMode.InPerson);

        // Act
        LoginCode result = _userService.GenerateLoginCode();

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
        Voter voter = new() { Id = "1" };
        _userService!.LogInUser(voter, LoginMode.InPerson);

        // Act
        LoginMode result = _userService.GetLoginMode();

        // Assert
        Assert.AreEqual(LoginMode.InPerson, result);
    }

    [TestMethod]
    public void TestGetAppCultureCode()
    {
        // Arrange
        Voter voter = new() { Id = "1", Country = Country.UK };
        string expected = "en-GB";

        // Act
        _userService!.LogInUser(voter, LoginMode.InPerson);
        string result = _userService.GetAppCultureCode();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestSetAppCultureCode()
    {
        // Arrange
        Voter voter = new() { Id = "1", Country = Country.UK };
        string expected = "en-GB";

        // Act
        _userService!.LogInUser(voter, LoginMode.InPerson);
        string result = _userService.GetAppCultureCode();

        // Assert
        Assert.AreEqual(expected, result);
    }
}
