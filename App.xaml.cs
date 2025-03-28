using CRUDLibrary.Models.DBModels;
using CRUDLibrary.Services;
using CRUDLibrary.ViewModels;
using CRUDLibrary.ViewModels.Inventory;
using CRUDLibrary.ViewModels.Loans;
using CRUDLibrary.ViewModels.Members;
using CRUDLibrary.Views.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Windows;
using System.Windows.Threading;

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

            Log.Information("(App.xaml.cs): Service provider built successfully.");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "(App.xaml.cs): App initialization failed.");
            throw;
        }
    }

    /// <inheritdoc/>
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Log.Information("(App.xaml.cs): CRUD Library Starting up");

        ConfigureExceptionHandlers();

        ValidateServices();

        try
        {
            Log.Information("(App.xaml.cs): Starting MainWindow");
            MainWindow = ServiceProvider!.GetRequiredService<MainWindow>();

            ShutdownMode = ShutdownMode.OnMainWindowClose;

            await Current.Dispatcher.InvokeAsync(() => { }, DispatcherPriority.ContextIdle);

            MainWindow.Show();
            
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "(App.xaml.cs): Failed to start MainWindow");
            throw;
        }
    }

    /// <inheritdoc/>
    protected override void OnExit(ExitEventArgs e)
    {
        Log.Information("(App.xaml.cs): App Exiting");
        Log.CloseAndFlush();
        base.OnExit(e);
    }

    private void ConfigureExceptionHandlers()
    {
        AppDomain.CurrentDomain.UnhandledException += (s, ex) =>
        {
            Log.Fatal(ex.ExceptionObject as Exception, "(App.xaml.cs): Unhandled Exception");
        };

        DispatcherUnhandledException += (s, ex) =>
        {
            Log.Error(ex.Exception, "(App.xaml.cs): UI thread exception");
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

        Log.Information(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
        Log.Information("Logger configured.");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(configure => configure.AddSerilog());

        Log.Information("(App.xaml.cs): Registering Dependency injection services.");

        services.AddSingleton<MainWindowViewModel>();

        services.AddDbContext<LibraryContext>(options =>
        {
            options.UseSqlite("Data Source=library.db");
            // TODO: remove in production
            options.EnableSensitiveDataLogging();
        });
        services.AddSingleton<LibraryService>();
        services.AddSingleton<IWindowService, WindowService>();

        services.AddTransient<InventoryPageViewModel>();
        services.AddTransient<MembersPageViewModel>();
        services.AddTransient<LoansPageViewModel>();

        services.AddTransient<MainWindow>();
        services.AddTransient<InventoryPage>();
        services.AddTransient<MembersPage>();
        services.AddTransient<LoansPage>();

        Log.Information("(App.xaml.cs): Dependency injection services registered.");
    }

    private static void ValidateServices()
    {
        var ViewModels = new Type[] {
                typeof(MainWindowViewModel),
                typeof(InventoryPageViewModel),
                typeof(MembersPageViewModel),
                typeof(LibraryContext),
                typeof(LibraryService),
                typeof(IWindowService),
                typeof(MainWindow),
                typeof(InventoryPage),
                typeof(MembersPage),
                typeof(LoansPage)
            };

        foreach (var service in ViewModels)
        {
            try
            {
                _ = ServiceProvider?.GetRequiredService(service);
                Log.Debug($"(App.xaml.cs): Resolved service: {service.Name}");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"(App.xaml.cs): Failed to resolve service: {service.Name}");
            }
        }
    }
}
