namespace VotifySystem.Common.BusinessLogic.Helpers;

/// <summary>
/// Helper class for internationalisation / localisation
/// </summary>
public static class LocalisationHelper
{
    /// <summary>
    /// Gets the Microsoft culture code for a given country
    /// </summary>
    /// <param name="country"></param>
    /// <returns>string of culture code for the country</returns>
    public static string GetCultureCode(Country country)
    {
        return _cultureCodes[country];
    }

    /// <summary>
    /// Dictionary of country and culture codes for use with CultureInfo
    /// </summary>
    private static readonly Dictionary<Country, string> _cultureCodes = new()
    {
        { Country.UK, "en-GB" },
        { Country.France, "fr-FR" }
    };

    /// <summary>
    /// gets the friendly name for the enum value of a country
    /// </summary>
    /// <param name="country">Country Type</param>
    /// <returns>string name of country</returns>
    public static string GetCountryName(Country country)
    {
        return country switch
        {
            Country.UK => "United Kingdom",
            Country.France => "France",
            _ => throw new ArgumentOutOfRangeException(nameof(country), country, "Country not found")
        };
    }
}

/// <summary>
/// Countries currently supported by the system
/// </summary>
public enum Country
{
    UK,
    France
}
