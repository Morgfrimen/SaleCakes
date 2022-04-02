using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleCakes.View;
using System;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using SaleCakes.View.Pages;
using Data.Repositories.Abstract;
using Data.Repositories;
using SaleCakes.ViewModel;


namespace SaleCakes;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private const string DefaultConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

    public IServiceProvider ServiceProvider { get; private set; }
    public IConfiguration Configuration { get; private set; }

    internal static string ConnectionString { get; private set; } = "";

    private void ConfigureServices(IServiceCollection services)
    {
        services.Configure<AppSettings>(Configuration.GetSection(nameof(ConnectionString)));

        services.AddDbContext<SaleCakesDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetValue<string>(nameof(ConnectionString)) ?? DefaultConnectionString);
            
        });

        //ViewModel
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<CakeAddViewModel>();
        services.AddTransient<CakeViewModel>();
        services.AddTransient<EmployeeAddViewModel>();

        //Page
        services.AddTransient<MainWindow>();
        services.AddTransient<CakesPage>();
        services.AddTransient<ClientsPage>();
        services.AddTransient<DecorPage>();
        services.AddTransient<EmployeePage>();
        services.AddTransient<MainMenuPage>();
        services.AddTransient<OrdersPage>();
        services.AddTransient<CakeAddView>();

        //Repositories
        services.AddTransient<IDecorRepositories, DecorRepositories>();
    }

    private static void GlobalErrorsEvent(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(SaleCakes.Properties.Resources.Message_Global_Error,
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
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        Configuration = builder.Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetService<MainWindow>();
        mainWindow.Closing += MainWindow_Closing;
        mainWindow.Show();
    }

    private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        this.Shutdown(0);
    }
}