using CRUDLibrary.Models.LibraryModels;
using Microsoft.EntityFrameworkCore;

namespace CRUDLibrary.Models.DBModels;

/// <summary>
/// Represents the database context for the library system.
/// Provides access to the Books, Members, and Loans tables.
/// </summary>
public class LibraryContext: DbContext
{
    /// <summary>
    /// Gets or sets the collection of books in the library.
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// Gets or sets the collection of members in the library.
    /// </summary>
    public DbSet<LibraryMember> Members { get; set; }

    /// <summary>
    /// Gets or sets the collection of loan records in the library.
    /// </summary>
    public DbSet<Loan> Loans { get; set; }

    /// <summary>
    /// Configures the database connection to use SQLite.
    /// </summary>
    /// <param name="options">The options builder used to configure the context.</param>
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }
}
