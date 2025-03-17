using CRUDLibrary.Services;
using CRUDLibrary.ViewModels;
using CRUDLibrary.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
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
        ConfigureLogger();

        try
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            Log.Information("Service provider built successfully.");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "App initialization failed.");
            throw;
        }
    }

    /// <inheritdoc/>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Log.Information("CRUD Library Starting up");

        ConfigureExceptionHandlers();

        ValidateServices();

        try
        {
            Log.Information("Starting MainWindow");
            var mainWindowViewModel = ServiceProvider!.GetRequiredService<MainWindowViewModel>();
            var mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.Show();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Failed to start MainWindow");
            throw;
        }
    }


    /// <inheritdoc/>
    protected override void OnExit(ExitEventArgs e)
    {
        Log.Information("App Exiting");
        Log.CloseAndFlush();
        base.OnExit(e);
    }

    private void ConfigureExceptionHandlers()
    {
        AppDomain.CurrentDomain.UnhandledException += (s, ex) =>
        {
            Log.Fatal(ex.ExceptionObject as Exception, "Unhandled Exception");
        };

        DispatcherUnhandledException += (s, ex) =>
        {
            Log.Error(ex.Exception, "UI thread exception");
            ex.Handled = true;
        };
    }

    private static void ConfigureLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Async(a => a.File("logs/log-.txt",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"))
            .CreateLogger();

        Log.Information("Logger configured.");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(configure => configure.AddSerilog());

        services.AddSingleton<MainWindowViewModel>();

        services.AddSingleton<LibraryService>();
        services.AddSingleton<IWindowService, WindowService>();

        services.AddTransient<InventoryPageViewModel>();
        services.AddTransient<MembersPageViewModel>();

        services.AddTransient<MainWindow>();
        services.AddTransient<InventoryPage>();
        services.AddTransient<MembersPage>();

        Log.Information("Dependency injection services registered.");
    }

    private static void ValidateServices()
    {
        var ViewModels = new Type[] {
                typeof(MainWindowViewModel),
                typeof(InventoryPageViewModel),
                typeof(LoansPageViewModel),
                typeof(MembersPageViewModel),
                typeof(LibraryService),
                typeof(IWindowService)
            };

        foreach (var service in ViewModels)
        {
            try
            {
                _ = ServiceProvider?.GetRequiredService(service);
                Log.Debug($"Resolved service: {service.Name}");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failed to resolve service: {service.Name}");
            }
        }
    }
}
