using CRUDLibrary.Models.Enums;

namespace CRUDLibrary.Models.LibraryModels;

/// <summary>
/// Represents a book in the library system.
/// </summary>
public record Book
{
    /// <summary>
    /// Gets or sets the unique identifier for the book.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the author of the book.
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ISBN (International Standard Member Number) of the book.
    /// </summary>
    public string ISBN { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the genre of the book.
    /// </summary>
    public BookGenre Genre { get; set; }

    /// <summary>
    /// Gets or sets a brief description of the book.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current availability status of the book.
    /// </summary>
    public BookStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the publication date of the book.
    /// </summary>
    public DateTime PublicationDate { get; set; }

    /// <summary>
    /// Gets or sets the collection of loans associated with this book.
    /// </summary>
    public ICollection<Loan> Loans { get; set; } = [];
}

