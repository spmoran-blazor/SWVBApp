using Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;
using AzureStaticWebApps.Blazor.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddStaticWebAppsAuthentication()
    .AddMudServices()
    .AddMsalAuthentication(options =>
    {
        options.ProviderOptions.DefaultAccessTokenScopes
        .Add("https://graph.microsoft.com/User.Read");
    });


await builder.Build().RunAsync();


//builder.Services.AddStaticWebAppsAuthentication(this IServiceCollection);
//builder.Services.AddMsalAuthentication(options =>

//{
//    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
//});