using CRUDLibrary.Models.LibraryModels;
using System.Collections.ObjectModel;

namespace CRUDLibrary.ViewModels;

/// <summary>
/// Represents a table entry for displaying book details in the library system.
/// </summary>
public class BookTableEntry
{
    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the author of the book.
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the genre of the book.
    /// </summary>
    public string Genre { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the status of the book (e.g., Available, Reserved, Out).
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier of the book.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets an empty instance of <see cref="BookTableEntry"/>.
    /// </summary>
    public static BookTableEntry Empty => new BookTableEntry
    {
        Title = string.Empty,
        Author = string.Empty,
        Genre = string.Empty,
        Status = string.Empty,
        Id = string.Empty
    };

    /// <summary>
    /// Converts a <see cref="Book"/> object into a <see cref="BookTableEntry"/>.
    /// </summary>
    /// <param name="book">The book to convert.</param>
    /// <returns>A new instance of <see cref="BookTableEntry"/> populated with book details.</returns>
    public static BookTableEntry ToBookTableEntry(Book book)
    {
        return new BookTableEntry
        {
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre.ToString(),
            Status = book.Status.ToString(),
            Id = book.Id.ToString()
        };
    }

    /// <summary>
    /// Converts a list of <see cref="Book"/> objects into <see cref="BookTableEntry"/> objects
    /// and adds them to the specified <see cref="ObservableCollection{BookTableEntry}"/>.
    /// </summary>
    /// <param name="books">The list of books to convert.</param>
    /// <param name="table">The collection to which the converted entries will be added.</param>
    public static void ToBookTableEntry(List<Book> books, ObservableCollection<BookTableEntry> table)
    {
        foreach (var book in books)
        {
            table.Add(ToBookTableEntry(book));
        }
    }

    /// <summary>
    /// Determines whether the specified <see cref="BookTableEntry"/> is equal to the current instance.
    /// </summary>
    /// <param name="book">The book entry to compare with the current instance.</param>
    /// <returns><c>true</c> if both book entries are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(BookTableEntry book)
    {
        return Title == book.Title &&
               Author == book.Author &&
               Genre == book.Genre &&
               Status == book.Status &&
               Id == book.Id;
    }
}
