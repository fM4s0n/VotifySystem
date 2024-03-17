using VotifySystem.Common.Classes;

namespace VotifySystem.Common.BusinessLogic.Helpers;

/// <summary>
/// Helper class for User objects
/// </summary>
internal class UserHelper
{
    /// <summary>
    /// Creates the initial administrator
    /// </summary>
    internal static Administrator CreateInitialAdministrator()
    {
        return new Administrator("Default","Admin", "DefaultAdmin", "Password");
    }
}
