using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MovieTheaterProject.UI;
using MovieTheaterProject.UI.Utilities.LoginManager;
using MovieTheaterProject.UI.Utilities.MovieManager;
using MovieTheaterProject.UI.Utilities.MovieTheaterManager;
using MovieTheaterProject.UI.Utilities.MovieViewingManager;
using MovieTheaterProject.UI.Utilities.ReservationManager;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddTransient<ILoginManager, LoginManager>();
builder.Services.AddTransient<IMovieManager, MovieManager>();
builder.Services.AddTransient<IMovieTheaterManager, MovieTheaterManager>();
builder.Services.AddTransient<IMovieViewingManager, MovieViewingManager>();
builder.Services.AddTransient<IReservationManager, ReservationManager>();

await builder.Build().RunAsync();
