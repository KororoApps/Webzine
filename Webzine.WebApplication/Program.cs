using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Webzine.EntitiesContext;

var builder = WebApplication.CreateBuilder(args);

// Charge la configuration en fonction de l'environnement
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}
else
{
    builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
}

// Ajoute le DbContext avec l'injection de dépendance
builder.Services.AddDbContext<WebzineDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure les services nécessaires
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Initialise NLog
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Redirection HTTPS si ce n'est pas en développement
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<WebzineDbContext>();

    // Assure la création de la base de données
    context.Database.EnsureDeleted();

    context.Database.EnsureCreated();

    // Votre opération de seeding
    SeedData.Initialize(services, context);
}

app.UseStaticFiles();
app.UseRouting();

app.Run();