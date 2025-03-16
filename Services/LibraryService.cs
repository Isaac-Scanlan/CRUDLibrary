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




    #region Create Methods

    /// <summary>
    /// Adds a new name to the database.
    /// </summary>
    /// <param name="book">The member to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Adds a new library member to the database
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    public async Task AddMemberAsync(LibraryMember member)
    {
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
    }

    #endregion




    #region Read Requests

    /// <summary>
    /// Retrieves all books from the database.
    /// </summary>
    /// <returns>A list of all books in the library.</returns>
    public async Task<List<Book>> GetBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    /// <summary>
    /// Retrieves a list of books that match the specified title.
    /// </summary>
    /// <param name="book">The title of the member to search for.</param>
    /// <returns>A list of books with the specified title.</returns>
    public async Task<List<Book>>? GetBooks(string book)
    {
        return await _context.Books.Where(b => b.Title == book).ToListAsync() ?? [];
    }

    /// <summary>
    /// Searches for books whose title contains the specified search term.
    /// </summary>
    /// <param name="searchTerm">The keyword used to filter member titles.</param>
    /// <returns>A list of books that match the search term.</returns>
    public async Task<List<Book>> GetBooksAsync(string searchTerm)
    {
        return await _context.Books
                             .Where(b => b.Title.ToLower().Contains(searchTerm.ToLower()))
                             .ToListAsync();
    }

    /// <summary>
    /// Retrieves books that match the specified member ID.
    /// </summary>
    /// <param name="idSearchTerm">The ID of the member to find.</param>
    /// <returns>A list of books with the specified ID.</returns>
    public async Task<List<Book>> GetBooksAsync(int idSearchTerm)
    {
        return await _context.Books
                             .Where(b => b.Id == idSearchTerm)
                             .ToListAsync();
    }

    /// <summary>
    /// Gets all Library members from the database
    /// </summary>
    /// <returns></returns>
    public async Task<List<LibraryMember>> GetMembersAsync()
    {
        return await _context.Members.ToListAsync();
    }

    /// <summary>
    /// Gets a particular Library member by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<List<LibraryMember>>? GetMember(string name)
    {
        return await _context.Members.Where(b => b.Name == name).ToListAsync() ?? [];
    }

    /// <summary>
    /// Gets a particular Library member by email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<List<LibraryMember>> GetMembersAsync(string email)
    {
        return await _context.Members
                             .Where(b => b.Email.ToLower().Contains(email.ToLower()))
                             .ToListAsync();
    }


    #endregion




    #region Update Requests

    /// <summary>
    /// Updates an existing member in the database.
    /// </summary>
    /// <param name="book">The member to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task UpdateBookAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing member in the database.
    /// </summary>
    /// <param name="member">The member to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task UpdateMemberAsync(LibraryMember member)
    {
        _context.Members.Update(member);
        await _context.SaveChangesAsync();
    }

    #endregion




    #region Delete Requests

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

    /// <summary>
    /// Deletes a member from the database.
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    public async Task DeleteMemberAsync(LibraryMember member)
    {
        _context.Members.Remove(member);
        await _context.SaveChangesAsync();
    }

    #endregion
}
