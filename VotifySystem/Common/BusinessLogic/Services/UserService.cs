using Microsoft.AspNetCore.Identity;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Classes;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Controls;

namespace VotifySystem.Common.BusinessLogic.Services;

/// <summary>
/// Singleton User Service
/// </summary>
public class UserService() : IUserService
{
    private readonly IDbService? _dbService;

    /// <summary>
    /// Constructor which handles being passed db service for testing only
    /// </summary>
    /// <param name="dbService">Mocked db service for testing</param>
    /// <param name="isForApp">true by default, false used for unit tests</param>
    public UserService(IDbService? dbService = null, bool isForApp = true) : this()
    {
        _dbService = isForApp ? Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService : dbService;
    }

    private User? _currentUser = null;
    private LoginMode _loginMode = LoginMode.InPerson;
    private Country _appCountry = Country.UK;

    // Define the public delegates for login and logout events
    public delegate void LogoutEventHandler(object sender, EventArgs e);
    public delegate void LoginEventHandler(object sender, EventArgs e);

    // Define the public events for login and logout events
    public event LogoutEventHandler? LogOutEvent;
    public event LoginEventHandler? LogInEvent;

    //<inheritdoc/>
    public User? GetCurrentUser() => _currentUser;

    //<inheritdoc/>
    public UserLevel GetCurrentUserLevel()
    {
        if (_currentUser == null)
            return UserLevel.None;

        return _currentUser.UserLevel;
    }

    //<inheritdoc/>
    public void LogInUser(User user, LoginMode loginMode)
    {
        _loginMode = loginMode;
        _currentUser = user;
        OnLogin();
    }

    //<inheritdoc/>
    public void LogOutUser()
    {
        _currentUser = null;
        OnLogout();
    }

    /// <summary>
    /// Login Event
    /// </summary>
    public void OnLogin() => LogInEvent?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// Logout Event
    /// </summary>
    public void OnLogout() => LogOutEvent?.Invoke(this, EventArgs.Empty);

    //<inheritdoc/>
    public string HashPassword(User user, string password)
    {
        PasswordHasher<User> passwordHasher = new();
        return passwordHasher.HashPassword(user, password);
    }

    //<inheritdoc/>
    public PasswordVerificationResult VerifyPassword(string plainPassword, User user)
    {
        PasswordHasher<User> passwordHasher = new();
        PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user, user.Password, plainPassword);
        return result;
    }

    //<inheritdoc/>
    public LoginCode GenerateLoginCode() => new(Guid.NewGuid().ToString()[..6], _currentUser!.Id);

    //<inheritdoc/>
    public LoginMode GetLoginMode() => _loginMode;

    //<inheritdoc/>
    public string GetAppCultureCode() => LocalisationHelper.GetCultureCode(_appCountry);

    //<inheritdoc/>
    public void SetAppLanguage(Country country) { _appCountry = country; }

    //<inheritdoc/>
    public User? GetUserByUsername(string username)
    {
        return _dbService!.GetDatabaseContext().Users.FirstOrDefault(u => u.Username == username) ?? null;
    }

    //<inheritdoc/>
    public User? GetUserById(string id)
    {
        return _dbService!.GetDatabaseContext().Users.FirstOrDefault(u => u.Id == id) ?? null;
    }

    //<inheritdoc/>
    public List<User>? GetAllUsers()
    {
        return _dbService!.GetDatabaseContext().Users.ToList() ?? null;
    }

    //<inheritdoc/>
    public List<User>? GetAllVoters()
    {
        return _dbService!.GetDatabaseContext().Users.Where(u => u.UserLevel == UserLevel.Voter).ToList();
    }

    //<inheritdoc/>
    public List<User>? GetAllAdministrators()
    {
        return _dbService!.GetDatabaseContext().Users.Where(u => u.UserLevel == UserLevel.Administrator).ToList();
    }

    //<inheritdoc/>
    public void InsertUser(User user) => _dbService!.InsertEntity(user);    

    //<inheritdoc/>
    public void UpdateUser(User user) => _dbService!.UpdateEntity(user);    

    //<inheritdoc/>
    public void DeleteUser(User user) => _dbService!.DeleteEntity(user);

    //<inheritdoc/>
    public List<LoginCode>? GetAllLoginCodes()
    {
        return _dbService!.GetDatabaseContext().LoginCodes.ToList() ?? null;
    }

    //<inheritdoc/>
    public LoginCode? GetLoginCodeByCode(string code)
    {
        return _dbService!.GetDatabaseContext().LoginCodes.FirstOrDefault(lc => lc.Code == code) ?? null;
    }

    //<inheritdoc/>
    public void InsertLoginCode(LoginCode loginCode)
    {
        _dbService!.InsertEntity(loginCode);
    }
}
