// <copyright file="Program.cs" company="Diiage 2026">
// Copyright (c) Diiage 2026. All rights reserved.
// </copyright>
using Bogus;

var builder = WebApplication.CreateBuilder(args);

// Ajoute les services nécessaires pour permettre l'utilisation des
// controllers avec des vues.
builder.Services.AddControllersWithViews()
    // Ajoute la compilation des vues lors de l'exécution de l'application.
    // Cela nous évite de recompiler l'application à chaque modification de vue.
    // Nécessite le package Nuget Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.
    .AddRazorRuntimeCompilation();

var app = builder.Build();

// Active la possibilité de servir des fichiers statiques présents dans
// le dossier wwwroot.
app.UseStaticFiles();

// Active le middleware permettant le routage des requêtes entrantes.
app.UseRouting();

// Exercice : Définissez vos routes ci-dessous.
// Ex 7.4

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
app.Run();

