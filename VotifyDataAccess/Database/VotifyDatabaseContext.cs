using Microsoft.EntityFrameworkCore;
using VotifySystem.Common.Classes

namespace VotifyDataAccess.Database;

/// <summary>
/// EFCore with SqLite
/// https://entityframeworkcore.com/providers-sqlite
/// </summary>
public class VotifyDatabaseContext : DbContext
{
    /// <summary>
    /// EFCore with SqLite
    /// https://entityframeworkcore.com/providers-sqlite
    /// </summary>
    /// <param name="options"></param>
    public VotifyDatabaseContext(DbContextOptions<VotifyDatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<Administrtor> Administrtors { get; set; }
}
