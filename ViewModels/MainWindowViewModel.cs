using CommunityToolkit.Mvvm.Input;
using CRUDLibrary.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
    private Page _currentPage;

    /// <summary>
    /// The view model for the Inventory Page.
    /// </summary>
    private readonly Page _inventoryPage;

    /// <summary>
    /// The view model for the Loans Page.
    /// </summary>
    private readonly Page _loansPage;

    /// <summary>
    /// The view model for the Members Page.
    /// </summary>
    private readonly Page _membersPage;

    /// <summary>
    /// The view model for the Overdue Page.
    /// </summary>
    private readonly Page _overduePage;

    /// <summary>
    /// Gets or sets the currently displayed page in the main window.
    /// Notifies the UI when the page changes.
    /// </summary>
    public Page CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;
            OnPropertyChanged(nameof(CurrentPage));
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


    private readonly ILogger<MainWindowViewModel> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// Sets up navigation commands and default page.
    /// </summary>
    public MainWindowViewModel(ILogger<MainWindowViewModel> logger, InventoryPage inventoryPage, MembersPage membersPage)
    {
        _logger = logger;

        _inventoryPage = inventoryPage;
        _loansPage = new LoansPage();
        _membersPage = membersPage;
        _overduePage = new OverduePage();

        _currentPage = _inventoryPage;

        NavigateToInventoryPage = new RelayCommand(() => CurrentPage = _inventoryPage);
        NavigateToLoansPage = new RelayCommand(() => CurrentPage = _loansPage);
        NavigateToMembersPage = new RelayCommand(() => CurrentPage = _membersPage);
        NavigateToOverduePage = new RelayCommand(() => CurrentPage = _overduePage);

        _logger.LogInformation("MainWindowViewModel constructed");
    }
}
