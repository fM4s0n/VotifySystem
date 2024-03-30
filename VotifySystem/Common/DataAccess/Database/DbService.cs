using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;

namespace VotifySystem.Common.DataAccess.Database;

/// <summary>
/// Database Service
/// </summary>
internal class DbService(VotifyDatabaseContext dbContext, IUserService userService) : IDbService
{
    private readonly VotifyDatabaseContext _dbContext = dbContext;
    private readonly IUserService? _userService = userService;

    /// <summary>
    /// Generic insert statement to insert a new entity into the Db
    /// - Includes call to SaveChanges
    /// </summary>
    /// <typeparam name="T">Type of the entity</typeparam>
    /// <param name="entity">The entity to be inserted</param>
    public void InsertEntity<T>(T entity) where T : class
    {
        try 
        {             
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }   
    }

    /// <summary>
    /// Delete a record from the Db
    /// </summary>
    /// <typeparam name="T">Type of the object to be deleted</typeparam>
    /// <param name="entity">Object to be deleted</param>
    public void DeleteRecord<T>(T entity) where T : class
    {
        try
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Gets the current
    /// </summary>
    /// <returns>current instance of VotifyDatabaseContext</returns>
    public VotifyDatabaseContext GetDatabaseContext() => _dbContext;

    /// <summary>
    /// Seed data to the Db if required
    /// </summary>
    public void SeedDataIfRequired()
    {
        try
        {
            if (_dbContext.Users.Any(a => a.Username == "DefaultAdmin") == false)
                InsertEntity(CreateInitialAdministrator());

            if (_dbContext.Users.Any(v => v.Username == "DefaultVoter") == false)
                InsertEntity(CreateInitialVoter());

            if (_dbContext.Parties.Any(p => p.Name == "Default Party") == false)
                InsertEntity(CreateDefaultParty());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error seeding data - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    /// <summary>
    /// Create the default voter for seed data
    /// </summary>
    /// <returns>Instance of the default voter</returns>
    private Voter CreateInitialVoter()
    {
        DateTime dob = new(year: 1980, 1, 1);
        Voter defaultVoter = new("Default", "Voter", "DefaultVoter", VoteMethod.InPerson, "Default address",dob, Country.UK);
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
