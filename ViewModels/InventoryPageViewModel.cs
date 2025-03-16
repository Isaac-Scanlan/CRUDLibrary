using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using CRUDLibrary.Models.Enums;
using System.Collections.ObjectModel;

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

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryPageViewModel"/> class.
    /// </summary>
    /// <param name="windowService">Service for managing windows and popups.</param>
    public InventoryPageViewModel(IWindowService windowService)
    {
        _windowService = windowService;
        if (App.ServiceProvider is not null)
        {
            _libraryService = App.ServiceProvider.GetRequiredService<LibraryService>();
        }
        else
        {
            throw new InvalidOperationException("ServiceProvider has not been initialised.");
        }

        _bookTableCollection = [];
        _book = string.Empty;
        _selectedBook = BookTableEntry.Empty;
        _bookTableEntry = BookTableEntry.Empty;

        SearchBookCommand = new AsyncRelayCommand(SearchBooksAsync);
        OpenPopupCommand = new AsyncRelayCommand(AddNewBook);
        OpenEditPopupCommand = new AsyncRelayCommand(EditBookInfo);
        DeleteEntryCommand = new AsyncRelayCommand(Removebook);

        BookTableEntry.ToBookTableEntry(_libraryService.GetBooksAsync().Result, _bookTableCollection);
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

        BookGenre bookGenre;
        bookGenre = genres.TryGetValue(NewBookTableEntry.Genre, out bookGenre) ? bookGenre : _defaultGenre;

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

        BookGenre bookGenre;
        bookGenre = genres.TryGetValue(NewBookTableEntry.Genre, out bookGenre) ? bookGenre : currentBook.Genre;

        currentBook.Title = NewBookTableEntry.Title.Equals(string.Empty) ? currentBook.Title : NewBookTableEntry.Title;
        currentBook.Author = NewBookTableEntry.Author.Equals(string.Empty) ? currentBook.Author : NewBookTableEntry.Author;
        currentBook.Genre = NewBookTableEntry.Genre.Equals(string.Empty) ? currentBook.Genre : bookGenre;

        await _libraryService.UpdateBookAsync(currentBook);
        BookTableCollection.Clear();
        BookTableEntry.ToBookTableEntry(_libraryService.GetBooksAsync().Result, _bookTableCollection);

        NewBookTableEntry = null;
    }

    /// <summary>
    /// Removes the selected book from the inventory.
    /// </summary>
    private async Task Removebook()
    {

        if (SelectedBook is null || SelectedBook.Equals(BookTableEntry.Empty))
        {
            return;
        }

        var currentBooks = await _libraryService.GetBooksAsync(int.Parse(SelectedBook.Id));
        var currentBook = currentBooks.FirstOrDefault();

        if (currentBook is null)
        {
            return;
        }

        await _libraryService.DeleteBookAsync(currentBook);

        BookTableCollection.Clear();
        BookTableEntry.ToBookTableEntry(_libraryService.GetBooksAsync().Result, _bookTableCollection);
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

}
