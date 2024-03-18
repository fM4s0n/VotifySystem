using VotifyDataAccess.Database;

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

    public VotifyDatabaseContext GetDatabaseContext()
    {
        return _dbContext;
    }
}
