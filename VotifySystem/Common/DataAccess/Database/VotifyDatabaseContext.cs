using Microsoft.EntityFrameworkCore;
using VotifySystem.Common.Classes;

namespace VotifyDataAccess.Database;

/// <summary>
/// EFCore with SqLite
/// https://entityframeworkcore.com/providers-sqlite
/// </summary>
/// <param name="options">DbContext Options</param>
public class VotifyDatabaseContext(DbContextOptions<VotifyDatabaseContext> options) : DbContext(options)
{
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Constituency> Constituencies { get; set; }
    public DbSet<ElectionCandidate> ElectionCandidates { get; set; }
    public DbSet<Voter> Voters { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>().ToTable("Administrator").HasKey(a => a.Id);
        modelBuilder.Entity<Candidate>().ToTable("Candidate").HasKey(c => c.Id);
        modelBuilder.Entity<Constituency>().ToTable("Constituency").HasKey(co => co.ConstituencyId);
        modelBuilder.Entity<ElectionCandidate>().ToTable("ElectionCandidate").HasNoKey();
        modelBuilder.Entity<Voter>().ToTable("Voter").HasKey(v => v.Id);
    }
}
