using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CRUDLibrary.ViewModels;

public abstract class CrudPageViewModel<TModel, TEntry> : ViewModelBase
{
    protected readonly IWindowService _windowService;
    protected readonly LibraryService _libraryService;

    private TModel _model { get; set; }
    private TEntry? _selectedEntry { get; set; }
    private TEntry? _newEntry { get; set; }
    private ObservableCollection<TEntry> _table;

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

    public TEntry? SelectedEntry
    {
        get => _selectedEntry;
        set
        {
            _selectedEntry = value;
            OnPropertyChanged(nameof(SelectedEntry));
        }
    }

    public TEntry? NewEntry
    {
        get => _newEntry;
        set
        {
            _newEntry = value;
            OnPropertyChanged(nameof(NewEntry));
        }
    }

    public ObservableCollection<TEntry> Table
    {
        get => _table;
        set
        {
            _table = value;
            OnPropertyChanged(nameof(Table));
        }
    }

    public ICommand SearchCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    /// <summary>
    /// Searches for TModel based on the input criteria.
    /// </summary>
    protected abstract Task SearchAsync();

    protected abstract Task AddAsync();

    protected abstract Task EditAsync();

    protected abstract Task DeleteAsync();

}
