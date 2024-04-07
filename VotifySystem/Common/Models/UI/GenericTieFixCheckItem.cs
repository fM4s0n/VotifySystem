namespace VotifySystem.Common.Models.UIClasses;

/// <summary>
/// Class to allow for checking and fixing ties 
/// in a generic way
/// </summary>
/// <param name="key">unique identifier</param>
/// <param name="position">Original position in the list</param>
/// <param name="value">Value to check for ties against</param>
public class GenericTieFixCheckItem(string key, int position, int value)
{
    public string Key { get; set; } = key;
    public int Position { get; set; } = position;
    public int Value { get; set; } = value;
}
