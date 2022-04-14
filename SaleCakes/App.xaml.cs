using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Data.Context;
using Data.Repositories;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleCakes.View;
using SaleCakes.View.Components;
using SaleCakes.View.Pages;
using SaleCakes.ViewModel;

namespace SaleCakes;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private const string DefaultConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";
    private static string _roleUser;

    public IServiceProvider ServiceProvider { get; private set; }
    public IConfiguration Configuration { get; private set; }

    internal static string ConnectionString { get; private set; } = "";

    public string RoleUser
    {
        get => _roleUser;
        set
        {
            _roleUser = value;
            ServiceProvider.GetService<OrderViewModel>().PriceVisible = Visibility.Visible;
            ServiceProvider.GetService<MainWindowViewModel>().UpdateAllProperty();
        }
    }

    private void ConfigureServices(IServiceCollection services)
    {
        _ = services.Configure<AppSettings>(Configuration.GetSection(nameof(ConnectionString)));

        _ = services.AddDbContext<SaleCakesDbContext>(options => options.UseSqlServer(Configuration.GetValue<string>(nameof(ConnectionString)) ?? DefaultConnectionString));

        //ViewModel
        _ = services.AddSingleton<MainWindowViewModel>();
        _ = services.AddSingleton<CakeAddViewModel>();
        _ = services.AddSingleton<CakeViewModel>();
        _ = services.AddSingleton<EmployeeViewModel>();
        _ = services.AddSingleton<RegistrationViewModel>();
        _ = services.AddSingleton<AuthorizedViewModel>();
        _ = services.AddSingleton<ClientsViewModel>();
        _ = services.AddSingleton<OrderViewModel>();

        //Page
        _ = services.AddTransient<MainWindow>();
        _ = services.AddTransient<CakesPage>();
        _ = services.AddTransient<ClientsPage>();
        _ = services.AddTransient<DecorPage>();
        _ = services.AddTransient<EmployeePage>();
        _ = services.AddTransient<MainMenuComponent>();
        _ = services.AddTransient<OrdersPage>();

        //View
        _ = services.AddTransient<RegistrationWindow>();
        _ = services.AddTransient<ComponentsCakeWindow>();

        //Repositories
        _ = services.AddTransient<IDecorRepositories, DecorRepositories>();
        _ = services.AddTransient<IDecorRepositories, DecorRepositories>();
        _ = services.AddTransient<IStuffingRepositories, StuffingRepositories>();
        _ = services.AddTransient<IShortcakeRepositories, ShortcakeRepositories>();
        _ = services.AddTransient<IAppUserRepositories, AppUserRepositories>();
        _ = services.AddTransient<ITierRepositories, TierRepositories>();
        _ = services.AddTransient<IAuthorizationUserRepositories, AuthorizationUserRepositories>();
    }

    private static void GlobalErrorsEvent(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        _ = MessageBox.Show(SaleCakes.Properties.Resources.Message_Global_Error + e.Exception.Message,
            SaleCakes.Properties.Resources.Title_MessageBox_Error,
            MessageBoxButton.OK,
            MessageBoxImage.Error,
            MessageBoxResult.OK);
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        DispatcherUnhandledException += GlobalErrorsEvent;

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);
        Configuration = builder.Build();

        ServiceCollection? serviceCollection = new();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        CheckConnection();
        var mainWindow = ServiceProvider.GetService<MainWindow>();
        mainWindow.Closing += MainWindow_Closing;
        mainWindow.Show();
    }

    private void CheckConnection()
    {
        var dbContext = ServiceProvider.GetService<SaleCakesDbContext>();

        if (dbContext!.Database.CanConnect() is false)
        {
            _ = MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }
    }

    private void MainWindow_Closing(object? sender, CancelEventArgs e)
    {
        Shutdown(0);
    }
}