﻿using Microsoft.Extensions.Configuration;
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

        services.AddDbContext<SaleCakesContext>(options =>
        {
            options.UseSqlServer(Configuration.GetValue<string>(nameof(ConnectionString)) ?? DefaultConnectionString);
            
        });

        services.AddTransient<MainWindow>();
        services.AddTransient<CakesPage>();
        services.AddTransient<ClientsPage>();
        services.AddTransient<DecorPage>();
        services.AddTransient<EmployeePage>();
        services.AddTransient<MainMenuPage>();
        services.AddTransient<OrdersPage>();
        services.AddTransient<CakeAddView>();
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
        builder.Build();

        var mainWindow = ServiceProvider.GetService<MainWindow>();
        mainWindow.Show();
    }
}