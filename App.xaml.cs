using CRUDLibrary.Services;
using CRUDLibrary.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CRUDLibrary;

/// <summary>
/// Represents the entry point of the WPF application.
/// Handles dependency injection setup and application-wide services.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Gets the application's service provider for resolving dependencies.
    /// </summary>
    public static IServiceProvider? ServiceProvider { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// Configures dependency injection before the application starts.
    /// </summary>
    public App()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    /// <summary>
    /// Configures dependency injection by registering application services.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<LibraryService>();
        services.AddSingleton<IWindowService, WindowService>();
        services.AddTransient<InventoryPageViewModel>();
    }
}
