using Microsoft.EntityFrameworkCore;
using VotifySystem.Common.Classes;

namespace VotifyDataAccess.Database;

/// <summary>
/// EFCore with SqLite
/// https://entityframeworkcore.com/providers-sqlite
/// </summary>
public class VotifyDatabaseContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public VotifyDatabaseContext(DbContextOptions<VotifyDatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Constituency> Constituencies { get; set; }
    public DbSet<ElectionCandidate> ElectionCandidates { get; set; }
    public DbSet<Voter> Voters { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=VotifyDB.db;");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>().ToTable(nameof(Administrator));
        modelBuilder.Entity<Candidate>().ToTable(nameof(Candidate));
        modelBuilder.Entity<Constituency>().ToTable(nameof(Constituency));
        modelBuilder.Entity<ElectionCandidate>().ToTable(nameof(ElectionCandidate));
        modelBuilder.Entity<Voter>().ToTable(nameof(Voter));
    }
}
