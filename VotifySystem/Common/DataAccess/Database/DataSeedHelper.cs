using Microsoft.EntityFrameworkCore;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Classes.Elections;

namespace VotifySystem.Common.DataAccess.Database;

/// <summary>
/// Data Seeder for the database
/// </summary>
internal class DataSeedHelper(IUserService userService, IDbService dbService)
{
    private readonly IUserService? _userService = userService;
    private readonly IDbService? _dbService = dbService;

    /// <summary>
    /// seeds data if the objects are not already in the database
    /// </summary>
    internal void SeedDataIfNeeded()
    {
        if (_dbService!.GetDatabaseContext().Users.Any(a => a.Username == "DefaultAdmin") == false)
            _dbService.InsertEntity(CreateInitialAdministrator());

        if (_dbService.GetDatabaseContext().Users.Any(v => v.Username == "DefaultVoter") == false)
            _dbService.InsertEntity(CreateInitialVoter());

        SeedParties();

        if (_dbService.GetDatabaseContext().Elections.Any(e => e.Description == "Example Election") == false)
            _dbService.InsertEntity(CreateExampleElection());
    }

    /// <summary>
    /// Seeds the example parties if they are not already in the database
    /// </summary>
    private void SeedParties()
    {
        foreach (Party party in new List<Party> { CreateDefaultParty(), CreateBlueParty(), CreateRedParty(), CreateGreenParty() })
        {
            if (_dbService!.GetDatabaseContext().Parties.Any(p => p.Name == party.Name) == false)
                _dbService.InsertEntity(party);
        }
    }

    /// <summary>
    /// Creates a new example election with candidates and constituencies
    /// </summary>
    /// <returns></returns>
    private FirstPastThePostElection CreateExampleElection()
    {
        string description = "Example Election";
        DateTime start = new(2024, 4, 1, 9,0,0);
        DateTime end = new(2024, 10, 1, 21, 0, 0);
        string userId = _dbService!.GetDatabaseContext().Users.First(u => u.Username == "DefaultAdmin").Id;

        Election election = ElectionFactory.CreateElection(ElectionVoteMechanism.FPTP, Country.UK , description, start, end, userId);

        // Create Constituencies
        Constituency leeds = new("Leeds", election.ElectionId, Country.UK);
        Constituency manchester = new("Manchester", election.ElectionId, Country.UK);

        _dbService.InsertRange(new List<Constituency> { leeds, manchester });

        // Create Candidates
        Candidate redCandidateLeeds = new("Red Candidate", "Leeds", leeds.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Red").PartyId, election.ElectionId);
        Candidate blueCandidateLeeds = new("Blue Candidate", "Leeds", leeds.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Blue").PartyId, election.ElectionId);
        Candidate redCandidateManchester = new("Red Candidate", "Manchester", manchester.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Red").PartyId, election.ElectionId);
        Candidate blueCandidateManchester = new("Blue Candidate", "Manchester", manchester.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Blue").PartyId, election.ElectionId);

        redCandidateLeeds.AddVotes(100);
        blueCandidateLeeds.AddVotes(200);
        redCandidateManchester.AddVotes(300);
        blueCandidateManchester.AddVotes(400);

        _dbService.InsertRange(new List<Candidate> { redCandidateLeeds, blueCandidateLeeds });

        return (FirstPastThePostElection)election;
    }

    /// <summary>
    /// Create the default party for seed data
    /// </summary>
    /// <returns>Default Party for seed data</returns>
    private static Party CreateDefaultParty() => new("Default Party", Country.UK);

    private static Party CreateRedParty() => new("Red", Country.UK);

    private static Party CreateBlueParty() => new("Blue", Country.UK);    

    private static Party CreateGreenParty() => new("Green", Country.UK);

    /// <summary>
    /// Create the default voter for seed data
    /// </summary>
    /// <returns>Instance of the default voter</returns>
    private Voter CreateInitialVoter()
    {
        DateTime dob = new(year: 1980, 1, 1);
        Voter defaultVoter = new("Default", "Voter", "DefaultVoter", VoteMethod.InPerson, "Default address", dob, Country.UK);
        defaultVoter.Password = _userService!.HashPassword(defaultVoter, "Password");

        return defaultVoter;
    }

    /// <summary>
    /// Create instance of the Default Administrator
    /// </summary>
    /// <returns>Default administrator for seed data</returns>
    private Administrator CreateInitialAdministrator()
    {
        Administrator defaultAdmin = new("Default", "Admin", "DefaultAdmin");
        defaultAdmin.Password = _userService!.HashPassword(defaultAdmin, "Password");

        return defaultAdmin;
    }
}
