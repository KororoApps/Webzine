using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Webzine.EntitiesContext;
using Webzine.Repository;
using Webzine.Repository.Contracts;


var builder = WebApplication.CreateBuilder(args);

// Charge la configuration en fonction de l'environnement.
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}
else
{
    builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
}

// Connexion � la base PostGreSQL
/*builder.Services.AddDbContext<WebzineDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));*/

// Connexion � la base SQLite
builder.Services.AddDbContext<WebzineDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

// Ajoute les repositories avec l'injection de d�pendance.
builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();

// Ajoute les repositories avec l'injection de d�pendance pour la base de donn�es.
/*builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
//builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();
builder.Services.AddScoped<ICommentaireRepository,DbCommentaireRepository>();*/

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
    SeedData.Initialize(services, context);
}

// Active la possibilit� de servir des fichiers statiques pr�sents dans le dossier wwwroot.
app.UseStaticFiles();
// Active le middleware permettant le routage des requ�tes entrantes.
app.UseRouting();

// Ex�cute l'application.
app.Run();