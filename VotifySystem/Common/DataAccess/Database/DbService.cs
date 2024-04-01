using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Services;

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
    /// Generic update statement to update an entity in the Db
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    /// <param name="entity">object to be updated</param>
    public void UpdateEntity<T>(T entity) where T : class
    {
        try
        {
            _dbContext.Set<T>().Update(entity);
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
    public void SeedData()
    {
        try
        {
            DataSeedHelper dataSeeder = new(_userService!, this);
            dataSeeder.SeedDataIfNeeded();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error seeding data - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

}
