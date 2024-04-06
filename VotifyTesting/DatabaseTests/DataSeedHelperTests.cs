//using NSubstitute;
//using VotifyDataAccess.Database;
//using VotifySystem.Common.BusinessLogic.Services;
//using VotifySystem.Common.Classes;
//using VotifySystem.Common.Classes.Elections;
//using VotifySystem.Common.DataAccess.Database;

//namespace VotifyTesting.DatabaseTests;

//[TestClass]
//public class DataSeedHelperTests
//{
//    private IUserService? _mockUserService;
//    private IDbService? _mockDbService;
//    private IVotifyDatabaseContext? _mockDataContext;

//    [TestInitialize]
//    public void SetUp()
//    {
//        _mockUserService = Substitute.For<IUserService>(); 
//        _mockDbService = Substitute.For<IDbService>(); 
//        _mockDataContext = Substitute.For<IVotifyDatabaseContext>();

//        IQueryable<Person> users = new List<Person>().AsQueryable();

//        _mockDbService.GetDatabaseContext().Returns(_mockDataContext);
//        _mockDataContext.Users.Returns(users); 
//    }

//    [TestMethod]
//    public void SeedDataIfNeeded_ShouldInsertInitialUsersWhenNotExists()
//    {
//        // Arrange
//        DataSeedHelper? helper = new DataSeedHelper(_mockUserService!, _mockDbService!);

//        // Act
//        helper.SeedDataIfNeeded();

//        // Assert
//        // Verifies InsertEntity was called twice (for DefaultAdmin and DefaultVoter)
//        _mockDbService!.Received(2).InsertEntity(Arg.Any<User>());

//        // Optionally, verify that specific user types were inserted
//        _mockDbService!.Received(1).InsertEntity(Arg.Is<User>(u => u.Username == "DefaultAdmin"));
//        _mockDbService!.Received(1).InsertEntity(Arg.Is<User>(u => u.Username == "DefaultVoter"));

//        // Verify that SeedParties and SeedElections were called
//        // This assumes you have some way to check these methods were called. It might require further mocking or a different approach if these methods are private.
//    }

//    [TestCleanup]
//    public void TearDown()
//    {
//        _mockDataContext = null;
//        _mockDbService = null;
//        _mockUserService = null;
//    }
//}
