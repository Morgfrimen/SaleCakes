using Data.Context;
using Data.Repositories;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace UnitTestNew;

public class Startup
{
    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }

    public Startup()
    {
        IConfigurationBuilder? builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        Configuration = builder.Build();

        ServiceCollection? serviceCollection = new();

        _ = serviceCollection.AddDbContext<SaleCakesDbContext>(options => options.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings")!));
        _ = serviceCollection.AddTransient<IDecorRepositories, DecorRepositories>();
        _ = serviceCollection.AddTransient<IStuffingRepositories, StuffingRepositories>();
        _ = serviceCollection.AddTransient<IShortcakeRepositories, ShortcakeRepositories>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
}