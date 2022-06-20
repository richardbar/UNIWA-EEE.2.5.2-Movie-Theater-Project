using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MovieTheaterProject.UI;
using MovieTheaterProject.UI.Utilities.LoginManager;
using MovieTheaterProject.UI.Utilities.MovieViewingManager;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddTransient<ILoginManager, LoginManager>();
builder.Services.AddTransient<IMovieViewingManager, MovieViewingManager>();

await builder.Build().RunAsync();
