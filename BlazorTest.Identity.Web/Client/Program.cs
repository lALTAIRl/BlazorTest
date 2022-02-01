using Blazored.LocalStorage;
using BlazorTest.Identity.Web.Client;
using BlazorTest.Identity.Web.Client.Interfaces;
using BlazorTest.Identity.Web.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IAccountService, AccountService>(client =>
    client.BaseAddress = new Uri("https://localhost:42045"));

builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
