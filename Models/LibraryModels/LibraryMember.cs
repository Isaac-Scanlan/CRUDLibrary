namespace CRUDLibrary.Models.LibraryModels;

/// <summary>
/// Represents a library member who can borrow books.
/// </summary>
public record LibraryMember
{
    /// <summary>
    /// Gets or sets the unique identifier for the library member.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the library member.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the email address of the library member.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the library member.
    /// </summary>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the collection of loans associated with the library member.
    /// Represents the borrowing history of the member.
    /// </summary>
    public ICollection<Loan> LoanHistory { get; set; } = [];
}
