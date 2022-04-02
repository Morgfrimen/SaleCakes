using Data.Context;
using Data.Repositories;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleCakes;
using System;
using System.IO;

namespace UnitTestNew;

public class Startup
{
    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }

    public Startup()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        Configuration = builder.Build();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<SaleCakesDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings")!);
        });
        serviceCollection.AddTransient<IDecorRepositories, DecorRepositories>();
        serviceCollection.AddTransient<IStuffingRepositories, StuffingRepositories>();
        serviceCollection.AddTransient<IShortcakeRepositories, ShortcakeRepositories>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
}