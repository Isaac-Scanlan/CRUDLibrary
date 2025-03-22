using CRUDLibrary.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CRUDLibrary;

/// <summary>
/// Represents the main window of the application.
/// Initializes the UI and sets up data binding to <see cref="MainWindowViewModel"/>.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// Retrieves the ViewModel from the dependency injection container.
    /// </summary>
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}