using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CRUDLibrary.ViewModels;

/// <summary>
/// A reusable abstract base ViewModel for pages that implement CRUD operations.
/// Designed to be extended by concrete ViewModels such as inventory or members pages.
/// </summary>
/// <typeparam name="TModel">The core data model type (e.g. Book, Member).</typeparam>
/// <typeparam name="TEntry">The table-bound view model or DTO for display in the UI.</typeparam>
public abstract class CrudPageViewModel<TModel, TEntry> : ViewModelBase
{
    /// <summary>
    /// Provides window management capabilities, such as displaying popups.
    /// </summary>
    protected readonly IWindowService _windowService;

    /// <summary>
    /// Provides access to the library's data service for performing CRUD operations.
    /// </summary>
    protected readonly LibraryService _libraryService;

    private TEntry? _selectedEntry { get; set; }
    private TEntry? _newEntry { get; set; }
    private ObservableCollection<TEntry> _table;

    /// <summary>
    /// Initializes a new instance of the <see cref="CrudPageViewModel{TModel, TEntry}"/> class.
    /// </summary>
    /// <param name="windowService">Service used to manage popup windows and dialogs.</param>
    /// <param name="libraryService">Service for interacting with the underlying data store.</param>
    protected CrudPageViewModel(IWindowService windowService, LibraryService libraryService)
    {
        _windowService = windowService;
        _libraryService = libraryService;

        _table = [];

        SearchCommand = new AsyncRelayCommand(SearchAsync);
        AddCommand = new AsyncRelayCommand(AddAsync);
        EditCommand = new AsyncRelayCommand(EditAsync);
        DeleteCommand = new AsyncRelayCommand(DeleteAsync);
    }

    /// <summary>
    /// Selected entry on the display table for the CRUD Library view.
    /// </summary>
    public TEntry? SelectedEntry
    {
        get => _selectedEntry;
        set
        {
            _selectedEntry = value;
            OnPropertyChanged(nameof(SelectedEntry));
        }
    }

    /// <summary>
    /// Display table for the CRUD Library Table.
    /// </summary>
    public TEntry? NewEntry
    {
        get => _newEntry;
        set
        {
            _newEntry = value;
            OnPropertyChanged(nameof(NewEntry));
        }
    }

    /// <summary>
    /// Display table for the CRUD Library view.
    /// </summary>
    public ObservableCollection<TEntry> Table
    {
        get => _table;
        set
        {
            _table = value;
            OnPropertyChanged(nameof(Table));
        }
    }

    /// <summary>
    /// Command to search for TModel entry in the database and display table
    /// </summary>
    public ICommand SearchCommand { get; }

    /// <summary>
    /// Command to add TModel entry to the  database and display table
    /// </summary>
    public ICommand AddCommand { get; }

    /// <summary>
    /// Command to edit TModel entry to the  database and display table
    /// </summary>
    public ICommand EditCommand { get; }

    /// <summary>
    /// Command to delete TModel entry to the database and display table
    /// </summary>
    public ICommand DeleteCommand { get; }

    /// <summary>
    /// Searches for TModel based on the input criteria.
    /// </summary>
    protected abstract Task SearchAsync();

    /// <summary>
    /// Adds TModel entry based on the input criteria.
    /// </summary>
    protected abstract Task AddAsync();

    /// <summary>
    /// Edits TModel entry based on the input criteria.
    /// </summary>
    protected abstract Task EditAsync();

    /// <summary>
    /// Deletes TModel entry based on the input criteria.
    /// </summary>
    protected abstract Task DeleteAsync();

}
