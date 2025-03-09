using CRUDLibrary.Services;
using CRUDLibrary.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CRUDLibrary.Views.Pages;

/// <summary>
/// Interaction logic for InventoryPage.xaml
/// </summary>
public partial class InventoryPage : Page
{
    /// <summary>
    /// Initialises components for InventoryPage
    /// </summary>
    public InventoryPage()
    {
        InitializeComponent();

        // Resolve dependencies from DI container
        var windowService = App.ServiceProvider?.GetRequiredService<IWindowService>();
        var viewModel = App.ServiceProvider?.GetRequiredService<InventoryPageViewModel>();

        DataContext = viewModel;
    }
}
