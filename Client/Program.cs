using AzureStaticWebApps.Blazor.Authentication;
using Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http;
using MudBlazor.Services;
using WVBApp.Shared.Data;
internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddHttpClient("DataAccessHttpClient", sp => sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
        builder.Services.AddTransient<DataAccessService, DataAccessService>();
        builder.Services
            .AddStaticWebAppsAuthentication()
            .AddMudServices();
            

        builder.Services.AddScoped(sp =>
            new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

        builder.Services.AddMsalAuthentication(options =>
        {
            options.ProviderOptions.DefaultAccessTokenScopes
                .Add("https://graph.microsoft.com/User.Read");
        });

        await builder.Build().RunAsync();
    }
}
