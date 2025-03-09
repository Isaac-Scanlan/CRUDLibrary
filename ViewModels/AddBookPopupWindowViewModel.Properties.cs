namespace CRUDLibrary.ViewModels;

public partial class AddBookPopupWindowViewModel
{
    /// <summary>
    /// Gets or sets the title of the new book.
    /// </summary>
    public string NewTitle
    {
        get => _newTitle;
        set
        {
            _newTitle = value;
            OnPropertyChanged(nameof(NewTitle));
        }
    }

    /// <summary>
    /// Gets or sets the author of the new book.
    /// </summary>
    public string NewAuthor
    {
        get => _newAuthor;
        set
        {
            _newAuthor = value;
            OnPropertyChanged(nameof(NewAuthor));
        }
    }

    /// <summary>
    /// Gets or sets the genre of the new book.
    /// </summary>
    public string NewGenre
    {
        get => _newGenre;
        set
        {
            _newGenre = value;
            OnPropertyChanged(nameof(NewGenre));
        }
    }

    /// <summary>
    /// Gets or sets the status of the new book (e.g., Available, Reserved, Out).
    /// </summary>
    public string NewStatus
    {
        get => _newStatus;
        set
        {
            _newStatus = value;
            OnPropertyChanged(nameof(NewStatus));
        }
    }

    /// <summary>
    /// Gets or sets the unique identifier of the new book.
    /// </summary>
    public string NewId
    {
        get => _newId;
        set
        {
            _newId = value;
            OnPropertyChanged(nameof(NewId));
        }
    }
}
