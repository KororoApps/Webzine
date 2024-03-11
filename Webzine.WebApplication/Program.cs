using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Webzine.EntitiesContext;
using Webzine.EntitiesContext.Seeders;
using Webzine.Repository;
using Webzine.Repository.Contracts;
using Webzine.Business.Contracts;
using Webzine.WebApplication.Filters;
using Webzine.Business;

var builder = WebApplication.CreateBuilder(args);


// V�rifie le type de SGBD � utiliser en fonction de la configuration.
if (builder.Configuration.GetSection("SGBD").Value == "SQLite")
{
    // Utilise SQLite comme SGBD par d�faut.
builder.Services.AddDbContext<WebzineDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")), ServiceLifetime.Scoped);
}

// V�rifie le type de SGBD � utiliser en fonction de la configuration.
if (builder.Configuration.GetSection("SGBD").Value == "PostgreSQL")
{
    // Utilise PostgreSQL comme SGBD.
    builder.Services.AddDbContext<WebzineDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")), ServiceLifetime.Scoped);
}

// Configure le type de repository � utiliser en fonction de la configuration.
if (builder.Configuration.GetSection("Repository").Value == "Local")
{
    // Utilise des repositories locaux.
    builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
    builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
    builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
    builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
}
else if (builder.Configuration.GetSection("Repository").Value == "db")
{
    // Utilise des repositories de base de donn�es.
    builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
    builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
    builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();
 builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
    builder.Services.AddScoped<IDashboardService, DashboardService>();
}

// Configure les services n�cessaires.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

//Injecting Filters
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(LoggingActionFilter));
});

// Initialise NLog.
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Redirection HTTPS si ce n'est pas en d�veloppement.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

/*Routes specifiques administration */

// Admin Artiste Create/Delete/Edit
app.MapControllerRoute(
    name: "adminArtistes",
    pattern: "/administration/artiste/{action}/{id?}",
    defaults: new { area = "Admin", controller = "Artiste" },
    constraints: new { action = "create|delete|edit" });

// Admin ArtistesListe
app.MapControllerRoute(
    name: "adminArtistesEdit",
    pattern: "/administration/artistes/",
    defaults: new { area = "Admin", controller = "Artiste", action = "Index" });


// Admin CommentaireSuprimer
app.MapControllerRoute(
    name: "dashboard",
    pattern: "/administration/dashboard/",
    defaults: new { area = "Admin", controller = "Dashboard", action = "Index" });


/*Routes specifiques consultation */

// Rechercher un titre ou un artiste
app.MapControllerRoute(
    name: "recherche",
    pattern: "recherche/",
    defaults: new { controller = "Recherche", action = "Index" });

// Liker un titre
app.MapControllerRoute(
    name: "liker",
    pattern: "titre/liker",
    defaults: new { controller = "Titre", action = "Liker" });

// Commenter un titre
app.MapControllerRoute(
    name: "commenter",
    pattern: "titre/commenter",
    defaults: new { controller = "Titre", action = "Commenter" });


// titre selon le style de musique d�mand�e
app.MapControllerRoute(
    name: "style",
    pattern: "titres/style/{style}/",
    defaults: new { controller = "Titre", action = "Style" });

// Titre par Id
app.MapControllerRoute(
    name: "titre",
    pattern: "titre/{Id}",
    defaults: new { controller = "Titre", action = "Index" });

// Page d'un artiste
app.MapControllerRoute(
    name: "artiste",
    pattern: "artiste/{nom}",
    defaults: new { controller = "Artiste", action = "Index" });

// Route pour la page Contact
app.MapControllerRoute(
        name: "contactPage",
        pattern: "contact/",
        defaults: new { controller = "Contact", action = "Index" });

// Route pour les pages � l'accueil
    app.MapControllerRoute(
        name: "accueilPage",
        pattern: "page/{NumeroPage}",
        defaults: new { controller = "Home", action = "Index" });

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

    var seederValue = builder.Configuration.GetSection("Seeder").Value;
    var repositoryValue = builder.Configuration.GetSection("Repository").Value;

    if (!string.IsNullOrWhiteSpace(seederValue) && repositoryValue == "db")
    {
        await SeedDataSpotify.Request(services, context, builder.Configuration.GetSection("Spotify"));
    }
    else
    {
        // Op�ration de seeding
        SeedDataLocal.Initialize(services, context);
    }

}

// Active la possibilit� de servir des fichiers statiques pr�sents dans le dossier wwwroot.
app.UseStaticFiles();

// Active le middleware permettant le routage des requ�tes entrantes.
app.UseRouting();

// Ex�cute l'application.
app.Run();
