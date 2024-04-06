using Microsoft.EntityFrameworkCore;
using NSubstitute;
using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.DataAccess.Database;

namespace VotifyTesting.DatabaseTests;

/// <summary>
/// DBService Tests
/// Not testing the actual database, just the service
/// therefore only need to mock the dbContext and userService
/// Actual database test covered by manual testing in the Test plan
/// Not testing SeedData() as it is not part of the service and is tested in the DataSeedHelperTests
/// </summary>
[TestClass]
public class DBServiceTests
{
    private VotifyDatabaseContext? _dbContext;
    private IUserService? _userService;
    private DbService? _dbService;

    [TestInitialize]
    public void SetUp()
    {
        // Mock the DbContext and IUserService
        _dbContext = Substitute.For<VotifyDatabaseContext>();
        _userService = Substitute.For<IUserService>();
        _dbService = new DbService(_dbContext, _userService);
    }

    [TestMethod]
    public void TestInsertEntity()
    {
        // Arrange
        Voter entity = new (); 
        DbSet<Voter>? dbSetMock = Substitute.For<DbSet<Voter>, IQueryable<Voter>>();
        _dbContext!.Set<Voter>().Returns(dbSetMock);

        // Act
        _dbService!.InsertEntity(entity);

        // Assert
        dbSetMock.Received(1).Add(entity);
        _dbContext.Received(1).SaveChanges();
    }

    [TestMethod]
    public void TestInsertRange()
    {
        // Arrange
        List<Voter> entities = 
        [
            new Voter() { Id = "1" },
            new Voter() { Id = "2" },
            new Voter() { Id = "3" }
        ];
        DbSet<Voter>? dbSetMock = Substitute.For<DbSet<Voter>, IQueryable<Voter>>();
        _dbContext!.Set<Voter>().Returns(dbSetMock);

        // Act
        _dbService!.InsertRange(entities);

        // Assert
        dbSetMock.Received(1).AddRange(entities);
        _dbContext.Received(1).SaveChanges();
    }

    [TestMethod]
    public void TestDeleteRecord()
    {
        // Arrange
        Voter entity = new ();
        DbSet<Voter>? dbSetMock = Substitute.For<DbSet<Voter>, IQueryable<Voter>>();
        _dbContext!.Set<Voter>().Returns(dbSetMock);

        // Act
        _dbService!.DeleteRecord(entity);

        // Assert
        dbSetMock.Received(1).Remove(entity);
        _dbContext.Received(1).SaveChanges();
    }

    [TestMethod]
    public void TestUpdateEntity()
    {
        // Arrange
        Voter entity = new ();
        DbSet<Voter>? dbSetMock = Substitute.For<DbSet<Voter>, IQueryable<Voter>>();
        _dbContext!.Set<Voter>().Returns(dbSetMock);

        // Act
        _dbService!.UpdateEntity(entity);

        // Assert
        dbSetMock.Received(1).Update(entity);
        _dbContext.Received(1).SaveChanges();
    }

    [TestMethod]
    public void TestGetDatabaseContext()
    {
        // Act
        VotifyDatabaseContext result = _dbService!.GetDatabaseContext();

        // Assert
        Assert.AreEqual(_dbContext, result);
    }

    [TestCleanup]
    public void TearDown()
    {
        _dbContext = null;
        _userService = null;
        _dbService = null;
    }
}
