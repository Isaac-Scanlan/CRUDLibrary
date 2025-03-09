namespace CRUDLibrary.Models.LibraryModels;

/// <summary>
/// Represents a loan transaction for a book borrowed by a library member.
/// </summary>
public record Loan
{
    /// <summary>
    /// Gets or sets the unique identifier for the loan transaction.
    /// </summary>
    public int LoanID { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the book being borrowed.
    /// </summary>
    public int BookID { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the borrower (library member).
    /// </summary>
    public int BorrowerID { get; set; }

    /// <summary>
    /// Gets or sets the date when the book was borrowed.
    /// </summary>
    public DateTime LoanDate { get; set; }

    /// <summary>
    /// Gets or sets the due date by which the book should be returned.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Gets or sets the date when the book was actually returned.
    /// This value is <c>null</c> if the book has not been returned yet.
    /// </summary>
    public DateTime? ReturnDate { get; set; }

    /// <summary>
    /// Gets or sets the book associated with this loan transaction.
    /// </summary>
    public Book Book { get; set; } = new Book();

    /// <summary>
    /// Gets or sets the borrower (library member) associated with this loan transaction.
    /// </summary>
    public required LibraryMember Borrower { get; set; }
}

