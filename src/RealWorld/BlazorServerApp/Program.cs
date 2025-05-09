using BlazorServerApp;
using BlazorServerApp.Authorization;
using BlazorServerApp.BackgroundServices;
using BlazorServerApp.Components;
using BlazorServerApp.Domain;
using BlazorServerApp.Domain.Abstractions;
using BlazorServerApp.Fakers;
using BlazorServerApp.Hubs;
using BlazorServerApp.Infrastructures;
using BlazorServerApp.Services;
using Bogus;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddSingleton<Faker<Customer>, CustomerFaker>();
builder.Services.AddSingleton<List<Customer>>(sp =>
{
    var faker = sp.GetRequiredService<Faker<Customer>>();

    var customers = faker.Generate(100);

    return customers;
});

builder.Services.AddSingleton<IProductRepository, FakeProductRepository>();
builder.Services.AddSingleton<Faker<Product>, ProductFaker>();
builder.Services.AddSingleton<List<Product>>(sp =>
{
    var faker = sp.GetRequiredService<Faker<Product>>();

    var products = faker.Generate(100);

    return products;
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IUserService, JsonPlaceholderUserService>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddHttpClient("nbp", client =>
{
    client.BaseAddress = new Uri("https://api.nbp.pl");
});

builder.Services.AddSignalR();

builder.Services.AddHostedService<DashboardBackgroundService>();

builder.Services.AddTransient<LocalStorage>();

/*
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("AdultPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("DateOfBirth");
        policy.Requirements.Add(new AdultRequirement(18));
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, AdultRequirementHandler>();

*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapHub<DashboardHub>("/signalr/dashboard");



app.Run();
