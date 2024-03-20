using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Classes;

namespace VotifySystem.Common.DataAccess.Database;

/// <summary>
/// Database Service
/// </summary>
internal class DbService(VotifyDatabaseContext dbContext) : IDbService
{
    private VotifyDatabaseContext _dbContext = dbContext;

    /// <summary>
    /// Generic insert statement to insert a new entity into the Db
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
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
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
            if (_dbContext.Administrators.Any(a => a.Username == "DefaultAdmin") == false)
                InsertEntity(CreateInitialAdministrator());


            if (_dbContext.Parties.Any(p => p.Name == "Default Parties") == false)
                InsertEntity(CreateDefaultParty());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error seeding data - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Create the default party for seed data
    /// </summary>
    /// <returns>Default Party for seed data</returns>
    private static Party CreateDefaultParty() => new ("Default Party", Country.UK);

    /// <summary>
    /// Create instance of the Default Administrator
    /// </summary>
    /// <returns>Default administrator for seed data</returns>
    private static Administrator CreateInitialAdministrator() => new ("Default", "Admin", "DefaultAdmin", "Password");
}
