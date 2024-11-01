﻿using VotifyDataAccess.Database;

namespace VotifySystem.Common.DataAccess.Database;

/// <summary>
/// Database Service
/// </summary>
public class DbService(VotifyDatabaseContext dbContext) : IDbService
{
    private readonly VotifyDatabaseContext _dbContext = dbContext;

    //<inheritdoc/>
    public VotifyDatabaseContext GetDatabaseContext() => _dbContext;

    //<inheritdoc/>
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

    //<inheritdoc/>
    public void InsertRange<T>(IEnumerable<T> entities) where T : class
    {
        try
        {
            _dbContext.Set<T>().AddRange(entities);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //<inheritdoc/>
    public void DeleteEntity<T>(T entity) where T : class
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

    //<inheritdoc/>
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
}
