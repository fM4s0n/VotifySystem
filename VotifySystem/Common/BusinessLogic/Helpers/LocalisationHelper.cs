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
}

public enum Country
{
    UK,
    France
}
