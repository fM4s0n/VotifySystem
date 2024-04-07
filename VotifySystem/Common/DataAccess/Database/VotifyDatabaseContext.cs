using Microsoft.EntityFrameworkCore;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;

namespace VotifyDataAccess.Database;

/// <summary>
/// EFCore with SQLite
/// https://entityframeworkcore.com/providers-sqlite
/// </summary>
/// <param name="options">DbContext Options</param>
public class VotifyDatabaseContext : DbContext
{
    public VotifyDatabaseContext(DbContextOptions<VotifyDatabaseContext> options) : base(options) { }

    public VotifyDatabaseContext() { }

    public DbSet<User> Users { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Constituency> Constituencies { get; set; }
    public DbSet<Party> Parties { get; set; }
    public DbSet<ElectionVoter> ElectionVoters { get; set; }
    public DbSet<Election> Elections { get; set; }
    public DbSet<LoginCode> LoginCodes { get; set; }

    /// <summary>
    /// Required for EFCore to create the database
    /// </summary>
    /// <param name="modelBuilder">Model builder passed in by EF Core</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>().ToTable("Administrator");
        modelBuilder.Entity<Voter>().ToTable("Voter");
        modelBuilder.Entity<Candidate>().ToTable("Candidate");
        modelBuilder.Entity<Constituency>().ToTable("Constituency");
        modelBuilder.Entity<Party>().ToTable("Party");
        modelBuilder.Entity<ElectionVoter>().ToTable("ElectionVoter").HasKey(ev => new { ev.ElectionId, ev.VoterId });
        modelBuilder.Entity<Election>()
            .ToTable("Election")
            .HasDiscriminator<string>("election_type")
            .HasValue<FirstPastThePostElection>("FPTP_Election")
            .HasValue<SingleTransferrableVoteElection>("STV_Election");
        modelBuilder.Entity<LoginCode>().ToTable("LoginCode");

        base.OnModelCreating(modelBuilder);
    }
}
