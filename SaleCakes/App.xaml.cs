﻿using System;
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
using SaleCakes.View.Pages;
using SaleCakes.ViewModel;
using SaleCakes.View.Components;

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
        _ = services.Configure<AppSettings>(Configuration.GetSection(nameof(ConnectionString)));

        _ = services.AddDbContext<SaleCakesDbContext>(options => options.UseSqlServer(Configuration.GetValue<string>(nameof(ConnectionString)) ?? DefaultConnectionString));

        //ViewModel
        _ = services.AddSingleton<MainWindowViewModel>();
        _ = services.AddSingleton<CakeAddViewModel>();
        _ = services.AddSingleton<CakeViewModel>();
        _ = services.AddSingleton<EmployeeAddViewModel>();
        _ = services.AddSingleton<RegistrationViewModel>();
        _ = services.AddSingleton<AuthorizedViewModel>();
        _ = services.AddSingleton<ClientsViewModel>();

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
        _ = MessageBox.Show(SaleCakes.Properties.Resources.Message_Global_Error,
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

        var mainWindow = ServiceProvider.GetService<MainWindow>();
        mainWindow.Closing += MainWindow_Closing;
        mainWindow.Show();
    }

    private void MainWindow_Closing(object? sender, CancelEventArgs e)
    {
        Shutdown(0);
    }
}