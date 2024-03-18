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
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    public void DeleteRecord<T>(T entity) where T : class
    {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public VotifyDatabaseContext GetDatabaseContext()
    {
        return _dbContext;
    }

    /// <summary>
    /// Seed data to the Db if required
    /// </summary>
    public void SeedDataIfRequired()
    {
        if (_dbContext.Administrators.Any( a => a.Username == "DefaultAdmin"))
        {
            InsertEntity(CreateInitialAdministrator());
        }
    }

    /// <summary>
    /// Create instance of the Default Administrator
    /// </summary>
    /// <returns>New instance of Administrator</returns>
    private static Administrator CreateInitialAdministrator()
    {
        return new Administrator("Default", "Admin", "DefaultAdmin", "Password");
    }
}
