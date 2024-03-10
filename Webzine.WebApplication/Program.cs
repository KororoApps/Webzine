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



/*Routes specifiques */

// Page d'un artiste
app.MapControllerRoute(
    name: "artiste",
    pattern: "artiste/{Nom}",
    defaults: new { controller = "Artiste", action = "Index" });

// Titre par Id
app.MapControllerRoute(
    name: "titre",
    pattern: "titre/{Id}",
    defaults: new { controller = "Titre", action = "Index" });
// Titre id
app.MapControllerRoute(
    name: "consulterTitre",
    pattern: "titre/{id}/{artiste}/{titre}",
    defaults: new { controller = "Titre", action = "Index" });

// titre selon le style de musique d�mand�e
app.MapControllerRoute(
    name: "style",
    pattern: "titres/style/{style}",
    defaults: new { controller = "Titres", action = "Index" });

// Admin ArtistesSupprimer
app.MapControllerRoute(
    name: "adminArtistesSupprimer",
    pattern: "/administration/artiste/delete/{id}",
    defaults: new { controller = "Artiste", action = "Delete" });

// Admin ArtistesEdit
app.MapControllerRoute(
    name: "adminArtistesEdit",
    pattern: "/administration/artiste/edit/{id}",
    defaults: new { controller = "Artiste", action = "Edit" });

// Admin TitreSuprimer
app.MapControllerRoute(
    name: "adminTitreEdit",
    pattern: "/administration/titre/delete/{id}",
    defaults: new { controller = "Titre", action = "Delete"});

// Admin TitreEdit
app.MapControllerRoute(
    name: "adminTitreEdit",
    pattern: "/administration/titre/edit/{id}",
    defaults: new { controller = "Titre", action = "Edit" });

// Admin StyleSuprimer
app.MapControllerRoute(
    name: "adminStyleEdit",
    pattern: "/administration/style/delete/{id}",
    defaults: new { controller = "Style", action = "Delete" });

// Admin StyleEdit
app.MapControllerRoute(
    name: "adminStyleEdit",
    pattern: "/administration/style/edit/{id}",
    defaults: new { controller = "Style", action = "Edit" });

// Admin CommentaireSuprimer
app.MapControllerRoute(
    name: "adminCommentaireEdit",
    pattern: "/administration/commentaire/delete/{id}",
    defaults: new { controller = "Commentaire", action = "Delete" });

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
