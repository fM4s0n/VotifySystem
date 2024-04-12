using VotifyDataAccess.Database;

namespace VotifySystem.Common.DataAccess.Database;

/// <summary>
/// Decorator class which add SeedData functionality to the IDbService
/// Seeddata is only called at frmMain so done as a decorator
/// as the SeedData functionality elsewhere
/// </summary>
public class SeedDataDbServiceDecorator(IDbService dbService) : IDbService
{
    private readonly IDbService _dbService = dbService;

    public VotifyDatabaseContext GetDatabaseContext() => _dbService.GetDatabaseContext();

    public void InsertEntity<T>(T entity) where T : class => _dbService.InsertEntity(entity);

    public void InsertRange<T>(IEnumerable<T> entities) where T : class => _dbService.InsertRange(entities);

    public void DeleteEntity<T>(T entity) where T : class => _dbService.DeleteEntity(entity);

    public void UpdateEntity<T>(T entity) where T : class => _dbService.UpdateEntity(entity);

    public void SeedData()
    {
        try
        {
            DataSeedHelper dataSeeder = new();
            dataSeeder.SeedDataIfNeeded();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error seeding data - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}
