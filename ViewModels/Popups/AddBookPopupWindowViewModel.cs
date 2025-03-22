using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Models.LibraryModels;
using CRUDLibrary.ViewModels.BaseViewModels;
using CRUDLibrary.ViewModels.Inventory;
using CRUDLibrary.ViewModels.Members;
using System.Windows.Input;

namespace CRUDLibrary.ViewModels.Popups;

/// <summary>
/// Represents the ViewModel for the Add Book Popup Window.
/// Handles user input and submission of new book details.
/// </summary>
public partial class AddBookPopupWindowViewModel : PopupWindowViewModel<Book, BookTableEntry>
{
    private string _newTitle;
    private string _newAuthor;
    private string _newGenre;
    private string _newStatus;
    private string _newId;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddBookPopupWindowViewModel"/> class.
    /// </summary>
    /// <param name="title">The initial title of the book.</param>
    /// <param name="author">The initial author of the book.</param>
    /// <param name="genre">The initial genre of the book.</param>
    /// <param name="closeAction">An action that is invoked when the popup is closed, returning a <see cref="BookTableEntry"/>.</param>
    public AddBookPopupWindowViewModel(string title, string author, string genre, Action<BookTableEntry> closeAction)
        : base(closeAction)
    {
		_newTitle = title;
        _newAuthor = author;
        _newGenre = genre;
        _newStatus = string.Empty;
        _newId = string.Empty;
    }

    /// <summary>
    /// Submits the book details and invokes the close action with a new <see cref="BookTableEntry"/>.
    /// </summary>
    protected override void Submit()
    {
        CloseAction.Invoke(new BookTableEntry
        {
            Title = NewTitle,
            Author = NewAuthor,
            Genre = NewGenre,
            Status = "Available",
            Id = "N/A",
        });
    }

}
