using CRUDLibrary.Models.LibraryModels;
using System.Collections.ObjectModel;

namespace CRUDLibrary.ViewModels;

/// <summary>
/// Represents a table entry for displaying member details in the library system.
/// </summary>
public class MemberTableEntry
{
    /// <summary>
    /// Gets or sets the title of the member.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the author of the member.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the genre of the member.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier of the member.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets an empty instance of <see cref="MemberTableEntry"/>.
    /// </summary>
    public static MemberTableEntry Empty => new MemberTableEntry
    {
        Name = string.Empty,
        Email = string.Empty,
        PhoneNumber = string.Empty,
        Id = string.Empty
    };

    /// <summary>
    /// Converts a <see cref="Book"/> object into a <see cref="MemberTableEntry"/>.
    /// </summary>
    /// <param name="member">The member to convert.</param>
    /// <returns>A new instance of <see cref="MemberTableEntry"/> populated with member details.</returns>
    public static MemberTableEntry ToMemberTableEntry(LibraryMember member)
    {
        return new MemberTableEntry
        {
            Name = member.Name,
            Email = member.Email,
            PhoneNumber = member.PhoneNumber,
            Id = member.Id.ToString()
        };
    }

    /// <summary>
    /// Converts a list of <see cref="Book"/> objects into <see cref="MemberTableEntry"/> objects
    /// and adds them to the specified <see cref="ObservableCollection{MemberTableEntry}"/>.
    /// </summary>
    /// <param name="members">The list of members to convert.</param>
    /// <param name="table">The collection to which the converted entries will be added.</param>
    public static void ToMemberTableEntry(List<LibraryMember> members, ObservableCollection<MemberTableEntry> table)
    {
        foreach (var book in members)
        {
            table.Add(ToMemberTableEntry(book));
        }
    }

    /// <summary>
    /// Determines whether the specified <see cref="MemberTableEntry"/> is equal to the current instance.
    /// </summary>
    /// <param name="member">The member entry to compare with the current instance.</param>
    /// <returns><c>true</c> if both member entries are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(MemberTableEntry member)
    {
        return Name == member.Name &&
               Email == member.Email &&
               PhoneNumber == member.PhoneNumber &&
               Id == member.Id;
    }
}
