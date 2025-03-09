using CRUDLibrary.Models.DBModels;
using CRUDLibrary.Models.LibraryModels;
using Microsoft.EntityFrameworkCore;

namespace CRUDLibrary.Services;

/// <summary>
/// Provides services for managing library books in the database.
/// </summary>
public class LibraryService
{
    private readonly LibraryContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="LibraryService"/> class
    /// and ensures that the database is created.
    /// </summary>
    public LibraryService()
    {
        _context = new LibraryContext();
        _context.Database.EnsureCreated();
    }

    /// <summary>
    /// Retrieves a list of books that match the specified title.
    /// </summary>
    /// <param name="book">The title of the book to search for.</param>
    /// <returns>A list of books with the specified title.</returns>
    public async Task<List<Book>>? GetBooks(string book)
    {
        return await _context.Books.Where(b => b.Title == book).ToListAsync() ?? [];
    }

    /// <summary>
    /// Retrieves all books from the database.
    /// </summary>
    /// <returns>A list of all books in the library.</returns>
    public async Task<List<Book>> GetBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    /// <summary>
    /// Searches for books whose title contains the specified search term.
    /// </summary>
    /// <param name="searchTerm">The keyword used to filter book titles.</param>
    /// <returns>A list of books that match the search term.</returns>
    public async Task<List<Book>> GetBooksAsync(string searchTerm)
    {
        return await _context.Books
                             .Where(b => b.Title.ToLower().Contains(searchTerm.ToLower()))
                             .ToListAsync();
    }

    /// <summary>
    /// Retrieves books that match the specified book ID.
    /// </summary>
    /// <param name="idSearchTerm">The ID of the book to find.</param>
    /// <returns>A list of books with the specified ID.</returns>
    public async Task<List<Book>> GetBooksAsync(int idSearchTerm)
    {
        return await _context.Books
                             .Where(b => b.Id == idSearchTerm)
                             .ToListAsync();
    }

    /// <summary>
    /// Adds a new book to the database.
    /// </summary>
    /// <param name="book">The book to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing book in the database.
    /// </summary>
    /// <param name="book">The book to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task UpdateBookAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes a book from the database.
    /// </summary>
    /// <param name="book">The book to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteBookAsync(Book book)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }
}
