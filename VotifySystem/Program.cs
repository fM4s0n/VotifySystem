using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VotifyDataAccess.Database;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem;

internal static class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        var userService = ServiceProvider.GetRequiredService<IUserService>();
        var dbService = ServiceProvider.GetRequiredService<IDbService>();

        frmMain.ShowForm(userService, dbService);
    }

    /// <summary>
    /// WinForms dependency injection code using the following StackOverflow code 
    /// https://stackoverflow.com/questions/70475830/how-to-use-dependency-injection-in-winforms
    /// </summary>
    /// <returns></returns>
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => {
                services.AddSingleton<IUserService, UserService>();
                services.AddSingleton<frmMain>();
                services.AddDbContext<VotifyDatabaseContext>(options =>
                    options.UseSqlite("Data Source=VotifyDB.db"));
                services.AddSingleton<IDbService>(provider =>
                {
                    var dbContext = provider.GetRequiredService<VotifyDatabaseContext>();
                    var userService = ServiceProvider!.GetRequiredService<IUserService>();
                    return new DbService(dbContext, userService);
                });
            });
    }
}