using BlazorCrud.Client.Pages;
using BlazorCrud.Components;
using BlazorCrud.Data;
using BlazorCrud.Services;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IGameService, GameDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.MapGet("/api/games/{id}", async (int id, IGameService gameService) => await gameService.GetByIdAsync(id));
app.MapPost("/api/games", async (GameDto dto, IGameService gameService) => await gameService.AddGameAsync(dto));
app.MapPut("/api/games", async (GameDto dto, IGameService gameService) => await gameService.UpdateGameAsync(dto));

app.Run();
