using Crud2.Client;
//using Crud2.Client.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient for calling the server API
// Replace localhost:5000 with the actual port your Server runs on
builder.Services.AddHttpClient<AppClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5000/");
});

// Also provide a general HttpClient (useful for fetching static files, etc.)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
