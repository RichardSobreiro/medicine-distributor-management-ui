using ManagementUI;
using ManagementUI.Authentication;
using ManagementUI.Services;
using ManagementUI.Services.IServices;
using ManagementUI.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<NotificationService>();

builder.Services.AddScoped<IProducsService, ProducsService>();
builder.Services.AddScoped<IMeasurementUnitsService, MeasurementUnitsService>();

#region Authentication
builder.Services.AddScoped(typeof(AccountClaimsPrincipalFactory<RemoteUserAccount>), typeof(CustomAccountFactory));
builder.Services.AddScoped<CustomAuthorizationHeaderHandler>();
var backendOrigin = builder.Configuration["BaseAPIUrl"]!;
builder.Services
    .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WebAPI"))
    .AddHttpClient("WebAPI", client => client.BaseAddress = new Uri(backendOrigin))
    .AddHttpMessageHandler<CustomAuthorizationHeaderHandler>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
builder.Services.AddCustomAuthentication(options =>
{
    builder.Configuration.Bind("Oidc", options.ProviderOptions);
    options.UserOptions.RoleClaim = "roles";
});
builder.Services.AddApiAuthorization();
#endregion

await builder.Build().RunAsync();
