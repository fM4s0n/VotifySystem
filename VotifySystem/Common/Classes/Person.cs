using System.ComponentModel.DataAnnotations.Schema;

namespace VotifySystem.Common.Classes;

public abstract class Person
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;

    [NotMapped]
    public string FullName { get { return $"{FirstName} {LastName}"; } }
}
