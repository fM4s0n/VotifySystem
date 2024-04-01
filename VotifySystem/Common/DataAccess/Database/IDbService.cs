using VotifyDataAccess.Database;

namespace VotifySystem.Common.DataAccess.Database;

public interface IDbService
{
    /// <summary>
    /// Deletes a record from the database
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    /// <param name="entity">the object to be deleted</param>
    void DeleteRecord<T>(T entity) where T : class;

    /// <summary>
    /// Generic insert statement to insert a new entity into the Db
    /// Includes call to SaveChanges
    /// </summary>
    /// <typeparam name="T">Type of the entity</typeparam>
    /// <param name="entity">The entity to be inserted</param>
    void InsertEntity<T>(T entity) where T : class;

    /// <summary>
    /// Generic update statement to update an entity in the Db
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    /// <param name="entity">The object being updated</param>
    void UpdateEntity<T>(T entity) where T : class;

    /// <summary>
    /// gets the current instance of VotifyDatabaseContext
    /// </summary>
    /// <returns>current instance of VotifyDatabaseContext</returns>
    VotifyDatabaseContext GetDatabaseContext();

    /// <summary>
    /// Seed data to the db if required
    /// </summary>
    void SeedData();
}