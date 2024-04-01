using Microsoft.EntityFrameworkCore;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Classes.Elections;

namespace VotifySystem.Common.DataAccess.Database;

/// <summary>
/// Data Seeder for the database
/// </summary>
internal class DataSeedHelper(IUserService userService, IDbService dbService)
{
    private readonly IUserService? _userService = userService;
    private readonly IDbService? _dbService = dbService;

    /// <summary>
    /// seeds data if the objects are not already in the database
    /// </summary>
    internal void SeedDataIfNeeded()
    {
        if (_dbService!.GetDatabaseContext().Users.Any(a => a.Username == "DefaultAdmin") == false)
            _dbService.InsertEntity(CreateInitialAdministrator());

        if (_dbService.GetDatabaseContext().Users.Any(v => v.Username == "DefaultVoter") == false)
            _dbService.InsertEntity(CreateInitialVoter());

        if (_dbService.GetDatabaseContext().Parties.Any(p => p.Name == "Default Party") == false)
            _dbService.InsertEntity(CreateDefaultParty());

        if (_dbService.GetDatabaseContext().Parties.Any(p => p.Name == "Blue") == false)
            _dbService.InsertEntity(CreateBlueParty());

        if (_dbService.GetDatabaseContext().Parties.Any(p => p.Name == "Red") == false)
            _dbService.InsertEntity(CreateRedParty());

        if (_dbService.GetDatabaseContext().Elections.Any(e => e.Description == "Example Election") == false)
            _dbService.InsertEntity(CreateExampleElection());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private FirstPastThePostElection CreateExampleElection()
    {
        string description = "Example Election";
        DateTime start = new(2024, 4, 1, 9,0,0);
        DateTime end = new(2022, 10, 1, 21, 0, 0);
        string userId = _dbService!.GetDatabaseContext().Users.First(u => u.Username == "DefaultAdmin").Id;

        Election election = ElectionFactory.CreateElection(ElectionVoteMechanism.FPTP, Country.UK , description, start, end, userId);

        // Create Constituencies

        // Create Candidates

        return (FirstPastThePostElection)election;
    }

    /// <summary>
    /// creates a Red Party
    /// </summary>
    /// <returns>New Instance of a Party</returns>
    private static Party CreateRedParty() => new("Red", Country.UK);

    /// <summary>
    /// Creates a Blue Party
    /// </summary>
    /// <returns>New Instance of a Party</returns>
    private static Party CreateBlueParty() => new("Blue", Country.UK);

    /// <summary>
    /// Create the default voter for seed data
    /// </summary>
    /// <returns>Instance of the default voter</returns>
    private Voter CreateInitialVoter()
    {
        DateTime dob = new(year: 1980, 1, 1);
        Voter defaultVoter = new("Default", "Voter", "DefaultVoter", VoteMethod.InPerson, "Default address", dob, Country.UK);
        defaultVoter.Password = _userService!.HashPassword(defaultVoter, "Password");

        return defaultVoter;
    }

    /// <summary>
    /// Create instance of the Default Administrator
    /// </summary>
    /// <returns>Default administrator for seed data</returns>
    private Administrator CreateInitialAdministrator()
    {
        Administrator defaultAdmin = new("Default", "Admin", "DefaultAdmin");
        defaultAdmin.Password = _userService!.HashPassword(defaultAdmin, "Password");

        return defaultAdmin;
    }

    /// <summary>
    /// Create the default party for seed data
    /// </summary>
    /// <returns>Default Party for seed data</returns>
    private static Party CreateDefaultParty() => new("Default Party", Country.UK);
}
