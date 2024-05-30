using Blazored.LocalStorage;
using Epoch.Lib;
using EpochBuilder.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace EpochBuilder;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
// Services
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddMudServices();
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddScoped<IArticleService, ArticleService>();

        var host = builder.Build();

        using var scope = host.Services.CreateScope();
        await InitializeStoresAsync(scope);

        await host.RunAsync();
    }

    private static async Task InitializeStoresAsync(IServiceScope scope)
    {
        var articleStore = scope.ServiceProvider.GetRequiredService<IArticleService>();
        await articleStore.InitializeAsync();
    }

    private static async Task InitializeIndexDbAsync(IServiceScope scope)
    {
        await using var db = scope.ServiceProvider.GetService<BrowserDbAccessor>();
        if (db != null)
            await db.InitializeAsync();
    }

}