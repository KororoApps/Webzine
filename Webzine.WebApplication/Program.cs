using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Webzine.Business;
using Webzine.Business.Contracts;
using Webzine.EntitiesContext;
using Webzine.EntitiesContext.Seeders;
using Webzine.Repository;
using Webzine.Repository.Contracts;
using Webzine.WebApplication.Filters;
using Webzine.WebApplication.Middlewares;

// Créer un nouveau builder pour l'application web.
var builder = WebApplication.CreateBuilder(args);

var seederValue = builder.Configuration.GetSection("Seeder").Value;

// Choix de l'utilisateur : Configure le type de Repository à utiliser en fonction de la configuration.
if (string.IsNullOrWhiteSpace(seederValue))
{
    // Ne pas utiliser de base de données.
    builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
    builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
    builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
    builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();
    builder.Services.AddScoped<IDashboardService, DashboardService>();
}
else if (builder.Configuration.GetSection("Repository").Value == "db")
{
    if (builder.Environment.IsDevelopment())
    {
        // Si environnement de développement : SGBD SQLite utilisé
        builder.Services.AddDbContext<WebzineDbContext>(
            options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")),
            ServiceLifetime.Scoped);
    }
    else
    {
        // Si environnement de production : SGBD Postgre utilisé
        builder.Services.AddDbContext<WebzineDbContext>(
            options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")),
            ServiceLifetime.Scoped);
    }

    // Créer une base de données.
    builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
    builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
    builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();
    builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
    builder.Services.AddScoped<IDashboardService, DashboardService>();
}

// Configure les services nécessaires.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Injecter les filtres
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(LoggingActionFilter));
});

// Initialise NLog.
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Ajoutez la configuration du système de journalisation ici.
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

// Construit l'application en utilisant les configurations précédemment définies.
var app = builder.Build();

// Redirection HTTPS si ce n'est pas en développement.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Active la possibilité de servir des fichiers statiques présents dans le dossier wwwroot.
app.UseStaticFiles();

// Active le middleware permettant le routage des requêtes entrantes.
app.UseRouting();

// Utilise le middleware personnalisé pour la journalisation des requêtes entrantes.
app.UseMiddleware<RequestLoggingMiddleware>();

// Mise en forme des routes

// Routes specifiques de l'administration :

// Liste des artistes
app.MapControllerRoute(
    name: "artistes",
    pattern: "administration/artistes/{id?}",
    defaults: new { area = "Administration", controller = "Artiste", action = "Index" });

// Liste des titres
app.MapControllerRoute(
    name: "titres",
    pattern: "administration/titres/{id?}",
    defaults: new { area = "Administration", controller = "Titre", action = "Index" });

// Liste des styles
app.MapControllerRoute(
    name: "styles",
    pattern: "administration/styles/{id?}",
    defaults: new { area = "Administration", controller = "Style", action = "Index" });

// Routes specifiques de la consultation :

// Liste des commentaires
app.MapControllerRoute(
    name: "commentaires",
    pattern: "administration/commentaires/{id}",
    defaults: new { area = "Administration", controller = "Commentaire", action = "Index" });

// Titres selon le style de musique démandé
app.MapControllerRoute(
    name: "style",
    pattern: "titres/style/{style}/",
    defaults: new { controller = "Titre", action = "Style" });

// Titre par Id
app.MapControllerRoute(
    name: "titre",
    pattern: "titre/{Id}",
    defaults: new { controller = "Titre", action = "Index" });

// Formulaire pour ajouter un commentaire au titre
app.MapControllerRoute(
    name: "commenter",
    pattern: "commenter/",
    defaults: new { controller = "Titre", action = "Commenter" });

// Page d'un artiste
app.MapControllerRoute(
    name: "artiste",
    pattern: "artiste/{nom}",
    defaults: new { controller = "Artiste", action = "Index" });

// Route pour les pages à l'accueil
app.MapControllerRoute(
    name: "accueilPage",
    pattern: "page/{NumeroPage}",
    defaults: new { controller = "Home", action = "Index" },
    constraints: new { page = @"\d+" });

// Définit les routes pour les controllers.
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

if (builder.Configuration.GetSection("Repository").Value == "db")
{
    // Si le choix est d'avoir une Base de donnée, la seeder :
    // Utilise un scope pour gérer les services.
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    // Récupère le DbContext du service scope.
    var context = services.GetRequiredService<WebzineDbContext>();

    if (!app.Environment.IsDevelopment())
    {
        // Environnement de prod : Pas de supression de la BDD, Création de la BDD
        context.Database.EnsureCreated();
    }
    else if (app.Environment.IsDevelopment())
    {
        // Environnement de dev : Suppression de la BDD puis Création de la BDD
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    if (builder.Configuration.GetSection("Seeder").Value == "spotify")
    {
        // Si la configuration "Seeder" n'est pas vide, seeder la BDD avec les données de Spotify
        await SeedDataSpotify.Request(context, builder.Configuration.GetSection("spotify"));
    }
    else if (builder.Configuration.GetSection("Seeder").Value == "local")
    {
        // Sinon seeder la BDD avec des fausses données
        SeedDataLocal.Initialize(context);
    }
}

// Exécute l'application.
app.Run();
