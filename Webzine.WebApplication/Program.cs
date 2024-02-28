// <copyright file="Program.cs" company="Diiage 2026">
// Copyright (c) Diiage 2026. All rights reserved.
// </copyright>
using Webzine.EntitiesContext;

//#if !DEBUG

//#endif

using NLog.Web;
using Microsoft.EntityFrameworkCore;
using (var context = new WebzineContext())
{

    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Ajoute les services nécessaires pour permettre l'utilisation des
    // controllers avec des vues.
    builder.Services.AddControllersWithViews()
        // Ajosute la compilation des vues lors de l'exécution de l'application.
        // Cela nous évite de recompiler l'application à chaque modification de vue.
        // Nécessite le package Nuget Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.
        .AddRazorRuntimeCompilation();

    var app = builder.Build();

    // Active la possibilité de servir des fichiers statiques présents dans
    // le dossier wwwroot.
    app.UseStaticFiles();

    // Active le middleware permettant le routage des requêtes entrantes.
    app.UseRouting();

    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }


    // Ajoute un endpoint permettant de router les urls
    // avec la forme /controller/action/id(optionnel).
    // Equivalent à app.MapDefaultControllerRoute()
    app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Récupère la chaîne de connexion à la base dans les paramètres
    // string? connect = builder.Configuration.GetConnectionString("WebzineConnect");

    //Enregistre la classe de contexte de données comme service
    //en lui indiquant la connexion à utiliser
    //builder.Services.AddDbContext<WebzineContext>(opt => opt.UseNpgsql(connect));

    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    
    
    //context.Database.Migrate();
    context.Artistes.Where(a => a.Nom.Length > 0).ToList().ForEach(a => Console.WriteLine(a.Nom));
    app.Run();
}
