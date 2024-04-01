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

    //<inheritdoc/>
    public VotifyDatabaseContext GetDatabaseContext() => _dbContext;

    //<inheritdoc/>
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
