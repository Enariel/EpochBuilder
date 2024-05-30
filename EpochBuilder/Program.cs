using Blazored.LocalStorage;
using Epoch.Lib;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EpochBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddDbContext<EpochDbContext>(db=>db.UseInMemoryDatabase("EpochDb"));
builder.Services.AddCascadingValue(sp => new SaveData());
await builder.Build().RunAsync();