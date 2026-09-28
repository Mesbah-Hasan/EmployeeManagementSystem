using EmployeeManagement.Shared;
using EmployeeManagement.Shared.Services;
using EmployeeManagement.Web;
using EmployeeManagement.Web.Components;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7258/")
});

builder.Services.AddScoped<IPlatformService, WebPlatformService>();
builder.Services.AddScoped<AuthState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(typeof(AssemblyMarker).Assembly)
    .AddInteractiveServerRenderMode();

app.Run();