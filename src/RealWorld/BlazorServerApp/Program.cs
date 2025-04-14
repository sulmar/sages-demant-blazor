using BlazorServerApp.Components;
using BlazorServerApp.Domain;
using BlazorServerApp.Domain.Abstractions;
using BlazorServerApp.Infrastructures;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddSingleton<List<Customer>>(sp =>
{
    var customers = new List<Customer>();
    customers.Add(new Customer { Id = 1, Name = "Customer #1", Email = "a@domain.com" });
    customers.Add(new Customer { Id = 2, Name = "Customer #2", Email = "b@domain.com" });
    customers.Add(new Customer { Id = 3, Name = "Customer #3", Email = "c@domain.com" });
    customers.Add(new Customer { Id = 4, Name = "Customer #4", Email = "d@domain.com" });
    customers.Add(new Customer { Id = 5, Name = "Customer #5", Email = "e@domain.com" });

    return customers;
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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

app.Run();
