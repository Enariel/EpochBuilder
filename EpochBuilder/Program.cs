using Blazored.LocalStorage;
using Epoch.Lib;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EpochBuilder;
using EpochBuilder.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Services
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContext<EpochDbContext>(db=>db.UseInMemoryDatabase("EpochDb"));
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<DataService>();
// Cascading values
builder.Services.AddCascadingValue(sp => new SaveData());
await builder.Build().RunAsync();