// <copyright file="Program.cs" company="Diiage 2026">
// Copyright (c) Diiage 2026. All rights reserved.
// </copyright>
using Bogus;

var builder = WebApplication.CreateBuilder(args);

// Ajoute les services n�cessaires pour permettre l'utilisation des
// controllers avec des vues.
builder.Services.AddControllersWithViews()
    // Ajoute la compilation des vues lors de l'ex�cution de l'application.
    // Cela nous �vite de recompiler l'application � chaque modification de vue.
    // N�cessite le package Nuget Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.
    .AddRazorRuntimeCompilation();

var app = builder.Build();

// Active la possibilit� de servir des fichiers statiques pr�sents dans
// le dossier wwwroot.
app.UseStaticFiles();

// Active le middleware permettant le routage des requ�tes entrantes.
app.UseRouting();

// Exercice : D�finissez vos routes ci-dessous.
// Ex 7.4

// Ajoute un endpoint permettant de router les urls
// avec la forme /controller/action/id(optionnel).
// Equivalent � app.MapDefaultControllerRoute()
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

