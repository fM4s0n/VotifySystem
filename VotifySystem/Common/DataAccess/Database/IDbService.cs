using VotifyDataAccess.Database;

namespace VotifySystem.Common.DataAccess.Database;

internal interface IDbService
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    void DeleteRecord<T>(T entity) where T : class;

    /// <summary>
    /// Generic insert statement to insert a new entity into the Db
    /// </summary>
    /// <typeparam name="T">Type of the entity</typeparam>
    /// <param name="entity">The entity to be inserted</param>
    void InsertEntity<T>(T entity) where T : class;

    /// <summary>
    /// Returns current instance of VotifyDatabaseContext
    /// </summary>
    /// <returns></returns>
    VotifyDatabaseContext GetDatabaseContext();

    /// <summary>
    /// Seed data to the db if required
    /// </summary>
    void SeedDataIfRequired();
}