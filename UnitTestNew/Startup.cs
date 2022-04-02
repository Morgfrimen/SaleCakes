using System;
using System.IO;
using Data.Context;
using Data.Repositories;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTestNew;

public class Startup
{
    public Startup()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);
        Configuration = builder.Build();

        ServiceCollection? serviceCollection = new();

        _ = serviceCollection.AddDbContext<SaleCakesDbContext>(options => options.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings")!));
        _ = serviceCollection.AddTransient<IDecorRepositories, DecorRepositories>();
        _ = serviceCollection.AddTransient<IStuffingRepositories, StuffingRepositories>();
        _ = serviceCollection.AddTransient<IShortcakeRepositories, ShortcakeRepositories>();
        _ = serviceCollection.AddTransient<IAppUserRepositories, AppUserRepositories>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public IServiceProvider ServiceProvider { get; }
    public IConfiguration Configuration { get; }
}