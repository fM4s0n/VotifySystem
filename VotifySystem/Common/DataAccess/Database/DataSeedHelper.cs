﻿using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.Models.Votes;
using static VotifySystem.Common.BusinessLogic.Helpers.VoterHelper;

namespace VotifySystem.Common.DataAccess.Database;

/// <summary>
/// Data Seeder for the database
/// </summary>
public class DataSeedHelper()
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
    private readonly IDbService? _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;
    private readonly IFPTPElectionVoteService? _fptpVoteService = Program.ServiceProvider!.GetService(typeof(IFPTPElectionVoteService)) as IFPTPElectionVoteService;
    
    /// <summary>
    /// seeds data if the objects are not already in the database
    /// </summary>
    public void SeedDataIfNeeded()
    {
        SeedDefaultAdmin();

        SeedDefaultVoter();

        SeedParties();

        SeedElections();
    }

    /// <summary>
    /// Seed the default voter account
    /// </summary>
    private void SeedDefaultVoter()
    {
        if (_dbService!.GetDatabaseContext().Users.Any(a => a.Username == "DefaultVoter") == false)
            _dbService.InsertEntity(CreateDefaultVoter());
    }

    /// <summary>
    /// Seed the default admin account
    /// </summary>
    private void SeedDefaultAdmin()
    {
        if (_dbService!.GetDatabaseContext().Users.Any(a => a.Username == "DefaultAdmin") == false)
            _dbService.InsertEntity(CreateDefaultAdministrator());
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
    /// Seeds the example elections if they are not already in the database
    /// </summary>
    private void SeedElections()
    {
        foreach (Election election in new List<Election> { CreateExampleElection(), CreateExampleCompletedElection(), CreateInProgressPreferentialElectionNoVotes() })
        {
            if (_dbService!.GetDatabaseContext().Elections.Any(e => e.Description == election.Description) == false)
                _dbService.InsertEntity(election);
        }
    }

    /// <summary>
    /// Creates a new example election with candidates and constituencies
    /// </summary>
    /// <returns>FPTP election</returns>
    private FirstPastThePostElection CreateExampleElection()
    {
        string description = "Example Election";
        DateTime start = new(2024, 4, 1, 9,0,0);
        DateTime end = new(2024, 10, 1, 21, 0, 0);
        string userId = _dbService!.GetDatabaseContext().Users.First(u => u.Username == "DefaultAdmin").Id;

        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        builder.SetDescription(description)
            .SetCountry(Country.UK)
            .SetDates(start, end)
            .SetElectionAdministratorId(userId)
            .SetElectionId();

        Election election = builder.Build();

        // Create Constituencies
        Constituency leeds = new("Leeds", election.ElectionId, Country.UK);
        Constituency manchester = new("Manchester", election.ElectionId, Country.UK);

        _dbService.InsertRange(new List<Constituency> { leeds, manchester });

        // Create Candidates
        Candidate redCandidateLeeds = new("Red Candidate", "Leeds", leeds.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Red").PartyId, election.ElectionId);
        Candidate blueCandidateLeeds = new("Blue Candidate", "Leeds", leeds.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Blue").PartyId, election.ElectionId);

        Candidate redCandidateManchester = new("Red Candidate", "Manchester", manchester.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Red").PartyId, election.ElectionId);
        Candidate blueCandidateManchester = new("Blue Candidate", "Manchester", manchester.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Blue").PartyId, election.ElectionId);

        for (int i = 0; i < 10; i++)
        {
            if (VoteFactory.CreateVote(election.ElectionId, ElectionVoteMechanism.FPTP) is FPTPElectionVote blueLeedsVote)
            {
                blueLeedsVote.CastVote(blueCandidateLeeds.Id);
                _fptpVoteService!.InsertVote(blueLeedsVote);
            }
                
        }

        for (int i = 0; i < 20; i++)
        {
            if (VoteFactory.CreateVote(election.ElectionId, ElectionVoteMechanism.FPTP) is FPTPElectionVote redLeedsVote)
            {
                redLeedsVote.CastVote(redCandidateLeeds.Id);
                _fptpVoteService!.InsertVote(redLeedsVote);
            }                   
        }

        for (int i = 0; i < 30; i++)
        {
            if (VoteFactory.CreateVote(election.ElectionId, ElectionVoteMechanism.FPTP) is FPTPElectionVote blueManchesterVote)
            {
                blueManchesterVote.CastVote(blueCandidateManchester.Id);
                _fptpVoteService!.InsertVote(blueManchesterVote);
            }
        }

        for (int i = 0; i < 40; i++)
        {
            if (VoteFactory.CreateVote(election.ElectionId, ElectionVoteMechanism.FPTP) is FPTPElectionVote redManchesterVote)
            {
                redManchesterVote.CastVote(redCandidateManchester.Id);
                _fptpVoteService!.InsertVote(redManchesterVote);
            }
        }

        _dbService.InsertRange(new List<Candidate> { redCandidateLeeds, blueCandidateLeeds });

        return (FirstPastThePostElection)election;
    }

    /// <summary>
    /// Created example completed election
    /// </summary>
    /// <returns>Instance of FPTP election that has finished</returns>
    private FirstPastThePostElection CreateExampleCompletedElection()
    {
        string description = "Example Completed Election";
        DateTime start = new(2024, 3, 1, 9, 0, 0);
        DateTime end = new(2024, 4, 1, 21, 0, 0);
        string? userId = _userService!.GetAllAdministrators()?.FirstOrDefault(u => u.Username == "DefaultAdmin")!.Id;

        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.FPTP);
        builder.SetDescription(description)
            .SetElectionId()
            .SetDescription(description)
            .SetDates(start, end)
            .SetElectionAdministratorId(userId!)
            .SetCountry(Country.UK);

        Election election = builder.Build();

        // Create Constituencies
        Constituency york = new("York", election.ElectionId, Country.UK);
        Constituency newcastle = new("newcastle", election.ElectionId, Country.UK);

        _dbService!.InsertRange(new List<Constituency> { york, newcastle });

        // Create Candidates
        Candidate redCandidateYork = new("Red Candidate", "york", york.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Red").PartyId, election.ElectionId);
        Candidate blueCandidateYork = new("Blue Candidate", "york", york.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Blue").PartyId, election.ElectionId);

        Candidate redCandidateNewcastle = new("Red Candidate", "newcastle", newcastle.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Red").PartyId, election.ElectionId);
        Candidate blueCandidateNewcastle = new("Blue Candidate", "newcastle", newcastle.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Blue").PartyId, election.ElectionId);

        for (int i = 0; i < 10; i++)
        {
            if (VoteFactory.CreateVote(election.ElectionId, ElectionVoteMechanism.FPTP) is FPTPElectionVote redYorkVote)
            {
                redYorkVote.CastVote(redCandidateYork.Id);
                _fptpVoteService!.InsertVote(redYorkVote);
            }
        }

        for (int i = 0; i < 20; i++)
        {
            if (VoteFactory.CreateVote(election.ElectionId, ElectionVoteMechanism.FPTP) is FPTPElectionVote blueYorkVote)
            {
                blueYorkVote.CastVote(blueCandidateYork.Id);
                _fptpVoteService!.InsertVote(blueYorkVote);
            }
        }

        for (int i = 0; i < 30; i++)
        {
            if (VoteFactory.CreateVote(election.ElectionId, ElectionVoteMechanism.FPTP) is FPTPElectionVote redNewcastleVote)
            {
                redNewcastleVote.CastVote(redCandidateNewcastle.Id);
                _fptpVoteService!.InsertVote(redNewcastleVote);
            }
        }

        for (int i = 0; i < 30; i++)
        {
            if (VoteFactory.CreateVote(election.ElectionId, ElectionVoteMechanism.FPTP) is FPTPElectionVote blueNewcastleVote)
            {
                blueNewcastleVote.CastVote(blueCandidateNewcastle.Id);
                _fptpVoteService!.InsertVote(blueNewcastleVote);
            }
        }

        _dbService.InsertRange(new List<Candidate> { redCandidateYork, blueCandidateYork, redCandidateNewcastle, blueCandidateNewcastle });

        return (FirstPastThePostElection)election;
    }

    /// <summary>
    /// Seeds a preferential election with no given to candidates
    /// </summary>
    /// <returns>instance of a preferential elction which is in progress but has no votes associated/></returns>
    private PreferentialVoteElection CreateInProgressPreferentialElectionNoVotes()
    {
        string description = "Example Preferential Election";
        DateTime start = new(2024, 4, 1, 7, 0, 0);
        DateTime end = new(2024, 10, 1, 21, 0, 0);
        string userId = _dbService!.GetDatabaseContext().Users.First(u => u.Username == "DefaultAdmin").Id;

        var builder = ElectionFactory.CreateBuilder(ElectionVoteMechanism.Preferential);
        builder.SetDescription(description);
        builder.SetDates(start, end);
        builder.SetElectionAdministratorId(userId);
        builder.SetCountry(Country.UK);
        builder.SetElectionId();

        PreferentialVoteElection election = (PreferentialVoteElection)builder.Build();

        // Create Constituencies
        Constituency leeds = new("Leeds", election.ElectionId, Country.UK);
        Constituency manchester = new("Manchester", election.ElectionId, Country.UK);

        _dbService.InsertRange(new List<Constituency> { leeds, manchester });

        // Create Candidates
        Candidate redCandidateLeeds = new("Red Candidate", "Leeds", leeds.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Red").PartyId, election.ElectionId);
        Candidate blueCandidateLeeds = new("Blue Candidate", "Leeds", leeds.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Blue").PartyId, election.ElectionId);

        Candidate redCandidateManchester = new("Red Candidate", "Manchester", manchester.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Red").PartyId, election.ElectionId);
        Candidate blueCandidateManchester = new("Blue Candidate", "Manchester", manchester.ConstituencyId, _dbService.GetDatabaseContext().Parties.First(p => p.Name == "Blue").PartyId, election.ElectionId);

        _dbService.InsertRange(new List<Candidate> { redCandidateLeeds, blueCandidateLeeds, redCandidateManchester, blueCandidateManchester });

        return election;
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
    private Voter CreateDefaultVoter()
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
    private Administrator CreateDefaultAdministrator()
    {
        Administrator defaultAdmin = new("Default", "Admin", "DefaultAdmin");
        defaultAdmin.Password = _userService!.HashPassword(defaultAdmin, "Password");

        return defaultAdmin;
    }
}
