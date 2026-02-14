using HotelManagement.WebApp.Client.IServices;
using HotelManagement.WebApp.Client.Provider;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Refit;
using System.Buffers.Text;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddRadzenComponents();
builder.Services.AddTransient<RefitRequestHandler>();

var baseUrl = builder.HostEnvironment.BaseAddress + "api";
if (baseUrl != null)
{
    builder.Services.AddRefitClient<IUserWebAppService>().ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(baseUrl);
    });

    builder.Services.AddRefitClient<IRoleWebAppService>().ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(baseUrl);
    });
}
await builder.Build().RunAsync();
