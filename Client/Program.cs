using AzureStaticWebApps.Blazor.Authentication;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using WVBApp.Shared.Services.Data;
using WVBApp.Shared.Services.State;
using Client;
internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddHttpClient("DataAccessHttpClient", sp => sp.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
        builder.Services.AddSingleton<DataAccessService, DataAccessService>();
        builder.Services.AddStaticWebAppsAuthentication();
        builder.Services.AddSingleton<StateAccessService, StateAccessService>();
        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 1500;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });

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

        builder.Services.AddBlazoredSessionStorage();

        await builder.Build().RunAsync();
    }
}
