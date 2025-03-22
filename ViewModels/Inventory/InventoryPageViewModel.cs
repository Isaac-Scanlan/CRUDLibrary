using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.Services;
using CRUDLibrary.Models.Enums;
using Microsoft.Extensions.Logging;
using CRUDLibrary.ViewModels.BaseViewModels;

namespace CRUDLibrary.ViewModels.Inventory;

/// <summary>
/// ViewModel for managing the inventory page of the library system.
/// Handles book searching, adding, editing, and deleting operations.
/// </summary>
public partial class InventoryPageViewModel : CrudPageViewModel<Book, BookTableEntry>
{
    private string _book;
    private readonly BookGenre _defaultGenre = BookGenre.Other;

    private ILogger<InventoryPageViewModel> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryPageViewModel"/> class.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="windowService">Service for managing windows and popups.</param>
    /// <param name="libraryService"></param>
    public InventoryPageViewModel(ILogger<InventoryPageViewModel> logger, IWindowService windowService, LibraryService libraryService)
        : base(windowService, libraryService)
    {
        _logger = logger;

        _book = string.Empty;
        SelectedEntry = null;
        NewEntry = null;
    }

    /// <summary>
    /// Initializes the ViewModel by loading the initial book collection.
    /// </summary>
    public async Task InitializeAsync()
    {
        await ReloadBookCollectionAsync();
    }

    /// <summary>
    /// Opens a popup for adding or editing a book.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="author">The author of the book.</param>
    /// <param name="genre">The genre of the book.</param>
    private void OpenPopup(string title, string author, string genre)
    {
        _windowService.ShowBookPopup(title, author, genre, result =>
        {
            NewEntry = result;
        });
    }

    /// <inheritdoc/>
    protected override async Task AddAsync()
    {
        OpenPopup(string.Empty, string.Empty, string.Empty);

        if (NewEntry is null)
        {
            return;
        }

        int newId = Table.Any()
            ? Table.Max(entry => int.Parse(entry.Id)) + 1
            : 0;

        NewEntry.Id = newId.ToString();
        Table.Add(NewEntry);

        var bookGenre = ParseGenre(NewEntry.Genre);

        await _libraryService.AddBookAsync(new Book
        {
            Id = newId,
            Title = NewEntry.Title,
            Author = NewEntry.Author,
            Description = "N/A",
            Genre = bookGenre,
            ISBN = Guid.NewGuid().ToString(),
            Status = BookStatus.Available,
            PublicationDate = DateTime.Now,
            Loans = []
        });

        await ReloadBookCollectionAsync();
        NewEntry = null;
    }

    /// <inheritdoc/>
    protected override async Task EditAsync()
    {
        if (SelectedEntry is null || SelectedEntry.Equals(BookTableEntry.Empty))
        {
            return;
        }

        OpenPopup(SelectedEntry.Title, SelectedEntry.Author, SelectedEntry.Genre.ToString());

        if (NewEntry is null)
        {
            return;
        }

        var currentBook = (await _libraryService.GetBooksAsync(int.Parse(SelectedEntry.Id))).FirstOrDefault();

        if (currentBook is null)
        {
            return;
        }

        BookGenre genre = string.IsNullOrWhiteSpace(NewEntry.Genre)
          ? currentBook.Genre
          : ParseGenre(NewEntry.Genre);

        currentBook.Title = string.IsNullOrWhiteSpace(NewEntry.Title) ? currentBook.Title : NewEntry.Title;
        currentBook.Author = string.IsNullOrWhiteSpace(NewEntry.Author) ? currentBook.Author : NewEntry.Author;
        currentBook.Genre = genre;

        await _libraryService.UpdateBookAsync(currentBook);
        await ReloadBookCollectionAsync();

        NewEntry = null;
    }

    /// <inheritdoc/>
    protected override async Task DeleteAsync()
    {
        if (SelectedEntry is null || SelectedEntry.Equals(BookTableEntry.Empty))
        {
            return;
        }

        var currentBook = (await _libraryService.GetBooksAsync(int.Parse(SelectedEntry.Id))).FirstOrDefault();

        if (currentBook is null)
        {
            return;
        }

        await _libraryService.DeleteBookAsync(currentBook);
        await ReloadBookCollectionAsync();
    }

    /// <inheritdoc/>
    protected override async Task SearchAsync()
    {
        var bookresults = await _libraryService.GetBooksAsync(Book);
        Table.Clear();

        BookTableEntry.ToBookTableEntry(bookresults, Table);
    }

    /// <summary>
    /// Reloads the book collection from the library service.
    /// </summary>
    private async Task ReloadBookCollectionAsync()
    {
        Table.Clear();

        var books = await _libraryService.GetBooksAsync();
        BookTableEntry.ToBookTableEntry(books, Table);
    }

    /// <summary>
    /// Parses the provided genre string into a <see cref="BookGenre"/> enum.
    /// </summary>
    /// <param name="genreString">The genre as a string.</param>
    /// <returns>The parsed genre or the default genre if not found.</returns>
    private BookGenre ParseGenre(string genreString)
    {
        if (genres.TryGetValue(genreString, out var genre))
        {
            return genre;
        }

        return _defaultGenre;
    }

}
