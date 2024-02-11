// <copyright file="HomeController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Bogus;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur principal gérant les actions liées à la page d'accueil.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Affiche la page d'accueil avec des données générées aléatoirement.
        /// </summary>
        /// <returns>Vue de la page d'accueil.</returns>
        public IActionResult Index()
        {
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Artiste.
            /// <summary>
            var fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName());

            /// <summary>
            /// Génération de 10 fausses instances de la classe Artiste.
            /// <summary>//
            var artistes = fakerArtiste.Generate(10);

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Style.
            /// <summary>
            var fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => f.Random.Word());

            /// <summary>
            /// Génération de 10 fausses instances de la classe Style.
            /// <summary>//
            var styles = fakerStyle.Generate(10);

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.DateCreation, f => f.Date.Recent())
                .RuleFor(t => t.Chronique, f =>
                {
                    var paragraph = f.Lorem.Paragraph();
                    return paragraph.Length <= 200 ? paragraph : paragraph.Substring(0, 200);
                })
                .RuleFor(t => t.UrlJaquette, f => f.Image.PicsumUrl().ToString())
                .RuleFor(t => t.Artiste, f => f.PickRandom(artistes))
                .CustomInstantiator(f => new Titre
                {
                    Styles = new List<Style> { f.PickRandom(styles) },
                })
                ;

            /// <summary>
            /// Génération de 3 fausse instance de la classe Titre.
            /// <summary>
            var titres = titreFaker.Generate(20);

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var titreModel = new GroupeTitreModel
            {
                Titres = titres,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(titreModel);
        }
    }
}