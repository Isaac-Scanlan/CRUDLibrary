using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.ViewModels.Inventory;
using System.Windows.Input;

namespace CRUDLibrary.ViewModels.Popups;

/// <summary>
/// Represents the ViewModel for the Add Book Popup Window.
/// Handles user input and submission of new book details.
/// </summary>
public partial class AddBookPopupWindowViewModel : ViewModelBase
{
    /// <summary>
    /// Gets the command that submits the new book details.
    /// </summary>
    public ICommand SubmitCommand { get; }

    private readonly Action<BookTableEntry> _closeAction;
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
    {
		_newTitle = title;
        _newAuthor = author;
        _newGenre = genre;
        _newStatus = string.Empty;
        _newId = string.Empty;

        _closeAction = closeAction;
        SubmitCommand = new RelayCommand(Submit);
    }

    /// <summary>
    /// Submits the book details and invokes the close action with a new <see cref="BookTableEntry"/>.
    /// </summary>
    private void Submit()
    {
        _closeAction.Invoke(new BookTableEntry
        {
            Title = NewTitle,
            Author = NewAuthor,
            Genre = NewGenre,
            Status = "Available",
            Id = "N/A",
        });
    }

}
