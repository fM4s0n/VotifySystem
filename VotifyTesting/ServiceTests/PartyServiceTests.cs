using Microsoft.EntityFrameworkCore;
using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services.Implementations;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models;

namespace VotifyTesting.ServiceTests;

[TestClass]
public class PartyServiceTests
{
    private PartyService? _partyService;
    private DbService? _dbService;

    [TestInitialize]
    public void SetUp()
    {
        DbContextOptionsBuilder<VotifyDatabaseContext> builder = new();

        builder.EnableDetailedErrors();
        builder.EnableSensitiveDataLogging();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        VotifyDatabaseContext context = new(builder.Options);
        _dbService = new DbService(context);

        _partyService = new PartyService(_dbService);
    }

    [TestMethod]
    public void TestInsertParty()
    {
        // Arrange
        Party party = new() { PartyId = "1" };

        // Act
        _partyService!.InsertParty(party);

        // Assert
        Assert.AreEqual(party, _dbService!.GetDatabaseContext().Parties.First(p => p.PartyId == "1"));
    }

    [TestMethod]
    public void TestUpdateParty()
    {
        // Arrange
        Party party = new() { PartyId = "1" };
        _partyService!.InsertParty(party);

        party.Name = "Party";
        party.Country = Country.UK;

        // Act
        _partyService!.UpdateParty(party);

        // Assert
        Assert.AreEqual(party, _dbService!.GetDatabaseContext().Parties.First(p => p.PartyId == "1"));
    }

    [TestMethod]
    public void TestDeleteParty()
    {
        // Arrange
        Party party = new() { PartyId = "1" };
        _partyService!.InsertParty(party);

        // Act
        _partyService!.DeleteParty(party);

        // Assert
        Assert.IsNull(_dbService!.GetDatabaseContext().Parties.FirstOrDefault(p => p.PartyId == "1"));
    }

    [TestMethod]
    public void TestGetAllParties()
    {
        // Arrange
        List<Party> expected = [];

        Party party1 = new() { PartyId = "1" };
        expected.Add(party1);

        Party party2 = new() { PartyId = "2" };
        expected.Add(party2);

        Party party3 = new() { PartyId = "3" };
        expected.Add(party3);

        _partyService!.InsertParty(party1);
        _partyService!.InsertParty(party2);
        _partyService!.InsertParty(party3);

        // Act
        List<Party>? result = _partyService!.GetAllParties();

        // Assert
        Assert.AreEqual(expected.Count, result!.Count);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestGetPartiesByCountry()
    {
        // Arrange
        List<Party> expected = [];

        Party party1 = new() { PartyId = "1", Country = Country.UK };
        expected.Add(party1);

        Party party2 = new() { PartyId = "2", Country = Country.France };

        _partyService!.InsertParty(party1);
        _partyService!.InsertParty(party2);

        // Act
        List<Party>? result = _partyService!.GetPartiesByCountry(Country.UK);

        // Assert
        Assert.AreEqual(1, result!.Count);
        Assert.AreEqual(Country.UK, result[0].Country);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestGetPartyById()
    {
        // Arrange
        Party party = new() { PartyId = "1" };
        _partyService!.InsertParty(party);

        // Act
        Party? result = _partyService!.GetPartyById("1");

        // Assert
        Assert.AreEqual(party, result);
    }
}
