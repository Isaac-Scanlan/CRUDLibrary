using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Views.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace CRUDLibrary.ViewModels;

/// <summary>
/// Main View Model for the application
/// </summary>
public class MainWindowViewModel: ViewModelBase
{
    /// <summary>
    /// The currently displayed page in the main window.
    /// </summary>
    private Page _currentViewModel;

    /// <summary>
    /// The view model for the Inventory Page.
    /// </summary>
    private readonly Page _inventoryPageViewModel;

    /// <summary>
    /// The view model for the Loans Page.
    /// </summary>
    private readonly Page _loansPageViewModel;

    /// <summary>
    /// The view model for the Members Page.
    /// </summary>
    private readonly Page _membersPageViewModel;

    /// <summary>
    /// The view model for the Overdue Page.
    /// </summary>
    private readonly Page _overduePageViewModel;

    /// <summary>
    /// Gets or sets the currently displayed page in the main window.
    /// Notifies the UI when the page changes.
    /// </summary>
    public Page CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }

    /// <summary>
    /// Command for navigating to the Inventory Page.
    /// </summary>
    public ICommand NavigateToInventoryPage { get; }

    /// <summary>
    /// Command for navigating to the Loans Page.
    /// </summary>
    public ICommand NavigateToLoansPage { get; }

    /// <summary>
    /// Command for navigating to the Members Page.
    /// </summary>
    public ICommand NavigateToMembersPage { get; }

    /// <summary>
    /// Command for navigating to the Overdue Page.
    /// </summary>
    public ICommand NavigateToOverduePage { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// Sets up navigation commands and default page.
    /// </summary>
    public MainWindowViewModel()
    {
        _inventoryPageViewModel = new InventoryPage();
        _loansPageViewModel = new LoansPage();
        _membersPageViewModel = new MembersPage();
        _overduePageViewModel = new OverduePage();

        _currentViewModel = _inventoryPageViewModel;

        NavigateToInventoryPage = new RelayCommand(() => CurrentViewModel = _inventoryPageViewModel);
        NavigateToLoansPage = new RelayCommand(() => CurrentViewModel = _loansPageViewModel);
        NavigateToMembersPage = new RelayCommand(() => CurrentViewModel = _membersPageViewModel);
        NavigateToOverduePage = new RelayCommand(() => CurrentViewModel = _overduePageViewModel);
    }
}
