namespace VotifySystem.Common.BusinessLogic.Helpers;

/// <summary>
/// Helper class for internationalisation / localisation
/// </summary>
public static class LocalisationHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="country"></param>
    /// <returns></returns>
    public static string GetCultureCode(Country country)
    {
        return _cultureCodes[country];
    }

    private static readonly Dictionary<Country, string> _cultureCodes = new()
    {
        { Country.UK, "en-GB" },
        { Country.France, "fr-FR" }
    };

    /// <summary>
    /// Returns a freindly name for the enum value of a country
    /// </summary>
    /// <param name="country">Country Type</param>
    /// <returns></returns>
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

public enum Country
{
    UK,
    France
}
