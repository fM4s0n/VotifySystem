using VotifySystem.Common.BusinessLogic.Helpers;

namespace VotifyTesting.HelperTests;

[TestClass]
public  class LocalisationHelperTests
{
    [TestMethod]
    public void TestGetCultureCode()
    {
        // Arrange
        Country uk = Country.UK;
        Country france = Country.France;

        // Act
        string? ukResult = LocalisationHelper.GetCultureCode(uk);
        string? franceResult = LocalisationHelper.GetCultureCode(france);

        // Assert
        Assert.AreEqual("en-GB", ukResult);
        Assert.AreEqual("fr-FR", franceResult);
    }

    [TestMethod]
    public void TestGetCountryName()
    {
        // Arrange
        Country uk = Country.UK;
        Country france = Country.France;

        // Act
        string? ukResult = LocalisationHelper.GetCountryName(uk);
        string? franceResult = LocalisationHelper.GetCountryName(france);

        // Assert
        Assert.AreEqual("United Kingdom", ukResult);
        Assert.AreEqual("France", franceResult);
    }
}
