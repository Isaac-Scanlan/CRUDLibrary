using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using CRUDLibrary.Models.Enums;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;

namespace CRUDLibrary.ViewModels;

/// <summary>
/// ViewModel for managing the inventory page of the library system.
/// Handles book searching, adding, editing, and deleting operations.
/// </summary>
public partial class InventoryPageViewModel : ViewModelBase
{
    private string _book;
    private BookTableEntry? _bookTableEntry;
    private BookTableEntry _selectedBook;
    private readonly BookGenre _defaultGenre = BookGenre.Other;
    private readonly IWindowService _windowService;
    private readonly LibraryService _libraryService;
    private ObservableCollection<BookTableEntry> _bookTableCollection;

    /// <summary>
    /// Command for searching books in the library.
    /// </summary>
    public ICommand SearchBookCommand { get; }

    /// <summary>
    /// Command for opening the add book popup.
    /// </summary>
    public ICommand OpenPopupCommand { get; }

    /// <summary>
    /// Command for opening the edit book popup.
    /// </summary>
    public ICommand OpenEditPopupCommand { get; }

    /// <summary>
    /// Command for deleting a selected book entry.
    /// </summary>
    public ICommand DeleteEntryCommand { get; }

    private ILogger<InventoryPageViewModel> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryPageViewModel"/> class.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="windowService">Service for managing windows and popups.</param>
    /// <param name="libraryService"></param>
    public InventoryPageViewModel(ILogger<InventoryPageViewModel> logger, IWindowService windowService, LibraryService libraryService)
    {
        _logger = logger;
        _windowService = windowService;
        _libraryService = libraryService;

        _bookTableCollection = [];
        _book = string.Empty;
        _selectedBook = BookTableEntry.Empty;
        _bookTableEntry = BookTableEntry.Empty;

        SearchBookCommand = new AsyncRelayCommand(SearchBooksAsync);
        OpenPopupCommand = new AsyncRelayCommand(AddNewBook);
        OpenEditPopupCommand = new AsyncRelayCommand(EditBookInfo);
        DeleteEntryCommand = new AsyncRelayCommand(RemoveBook);
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
            NewBookTableEntry = result;
        });
    }

    /// <summary>
    /// Adds a new book to the inventory.
    /// </summary>
    private async Task AddNewBook()
    {
        OpenPopup(string.Empty, string.Empty, string.Empty);

        if (NewBookTableEntry is null)
        {
            return;
        }

        int newId = BookTableCollection.Any()
            ? BookTableCollection.Max(entry => int.Parse(entry.Id)) + 1
            : 0;

        NewBookTableEntry.Id = newId.ToString();
        BookTableCollection.Add(NewBookTableEntry);

        var bookGenre = ParseGenre(NewBookTableEntry.Genre);

        await _libraryService.AddBookAsync(new Book
        {
            Id = newId,
            Title = NewBookTableEntry.Title,
            Author = NewBookTableEntry.Author,
            Description = "N/A",
            Genre = bookGenre,
            ISBN = Guid.NewGuid().ToString(),
            Status = BookStatus.Available,
            PublicationDate = DateTime.Now,
            Loans = []
        });

        await ReloadBookCollectionAsync();
        NewBookTableEntry = null;

    }

    /// <summary>
    /// Edits an existing book entry in the inventory.
    /// </summary>
    private async Task EditBookInfo()
    {

        if (SelectedBook is null || SelectedBook.Equals(BookTableEntry.Empty))
        {
            return;
        }

        OpenPopup(SelectedBook.Title, SelectedBook.Author, SelectedBook.Genre.ToString());

        if (NewBookTableEntry is null)
        {
            return;
        }

        var currentBooks = await _libraryService.GetBooksAsync(int.Parse(SelectedBook.Id));
        var currentBook = currentBooks.FirstOrDefault();

        if (currentBook is null)
        {
            return;
        }

        BookGenre genre = string.IsNullOrWhiteSpace(NewBookTableEntry.Genre)
          ? currentBook.Genre
          : ParseGenre(NewBookTableEntry.Genre);

        currentBook.Title = string.IsNullOrWhiteSpace(NewBookTableEntry.Title) ? currentBook.Title : NewBookTableEntry.Title;
        currentBook.Author = string.IsNullOrWhiteSpace(NewBookTableEntry.Author) ? currentBook.Author : NewBookTableEntry.Author;
        currentBook.Genre = genre;

        await _libraryService.UpdateBookAsync(currentBook);
        await ReloadBookCollectionAsync();

        NewBookTableEntry = null;
    }

    /// <summary>
    /// Removes the selected book from the inventory.
    /// </summary>
    private async Task RemoveBook()
    {

        if (SelectedBook is null || SelectedBook.Equals(BookTableEntry.Empty))
        {
            return;
        }

        var currentBook = (await _libraryService.GetBooksAsync(int.Parse(SelectedBook.Id))).FirstOrDefault();

        if (currentBook is null)
        {
            return;
        }

        await _libraryService.DeleteBookAsync(currentBook);
        await ReloadBookCollectionAsync();
    }

    /// <summary>
    /// Searches for books based on the input criteria.
    /// </summary>
    private async Task SearchBooksAsync()
    {

        var bookresults = await _libraryService.GetBooksAsync(Book);
        _bookTableCollection.Clear();

        BookTableEntry.ToBookTableEntry(bookresults, _bookTableCollection);

    }

    /// <summary>
    /// Reloads the book collection from the library service.
    /// </summary>
    private async Task ReloadBookCollectionAsync()
    {
        _bookTableCollection.Clear();

        var books = await _libraryService.GetBooksAsync();
        BookTableEntry.ToBookTableEntry(books, _bookTableCollection);
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
