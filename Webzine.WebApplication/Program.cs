using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Webzine.EntitiesContext;
using Webzine.EntitiesContext.Seeders;
using Webzine.Repository;
using Webzine.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

// V�rifie le type de SGBD � utiliser en fonction de la configuration.
if (builder.Configuration.GetSection("AppSettings:SGBD").Value == "SQLite")
{
    // Utilise SQLite comme SGBD.
    builder.Services.AddDbContext<WebzineDbContext>(options =>
  options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
}
else if (builder.Configuration.GetSection("AppSettings:SGBD").Value == "PostgreSQL")
{
    // Utilise PostgreSQL comme SGBD.
    builder.Services.AddDbContext<WebzineDbContext>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
}

// Configure le type de repository � utiliser en fonction de la configuration.
if (builder.Configuration.GetSection("AppSettings:Repository").Value == "Local")
{
    // Utilise des repositories locaux.
    builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
    builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
    builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
    builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();
}
else
{
    // Utilise des repositories de base de donn�es.
    builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
    builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
    builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();
    builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
}

// Configure les services n�cessaires.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Initialise NLog.
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Redirection HTTPS si ce n'est pas en d�veloppement.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// D�finit les routes pour les controllers.
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Utilise un scope pour g�rer les services.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // R�cup�re le DbContext du service scope.
    var context = services.GetRequiredService<WebzineDbContext>();

    // Assure la suppression de la base de donn�es.
    context.Database.EnsureDeleted();

    // Assure la cr�ation de la base de donn�es.
    context.Database.EnsureCreated();

    // Op�ration de seeding
    SeedDataLocal.Initialize(services, context);
}

// Active la possibilit� de servir des fichiers statiques pr�sents dans le dossier wwwroot.
app.UseStaticFiles();

// Active le middleware permettant le routage des requ�tes entrantes.
app.UseRouting();

// Ex�cute l'application.
app.Run();