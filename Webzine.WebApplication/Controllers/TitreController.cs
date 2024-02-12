﻿// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Bogus;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des titres.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la chronique d'un titre.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    public class TitreController : Controller
    {
        /// <summary>
        /// Action qui affiche la liste des titres.
        /// </summary>
        /// <returns>Vue avec la liste des titres générés.</returns>
        public IActionResult Index()
        {

            /// <summary>
            /// Fonction pour mettre en majuscule la première lettre.
            /// <summary>// Fonction pour mettre en majuscule la première lettre
            static string CapitalizeFirstLetter(string input)
            {
                if (string.IsNullOrEmpty(input))
                {
                    return input;
                }

                return char.ToUpper(input[0]) + input[1..];
            }

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Artiste.
            /// <summary>
            var fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName());

            /// <summary>
            /// Génération de 1 fausse instance de la classe Artiste.
            /// <summary>//
            var artiste = fakerArtiste.Generate();

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Commentaire.
            /// <summary>
            var fakerCommentaire = new Faker<Commentaire>()
                .RuleFor(c => c.Auteur, f => f.Name.FullName())
                .RuleFor(c => c.Contenu, f => f.Lorem.Paragraph())
                .RuleFor(c => c.DateCreation, f => f.Date.Recent());

            /// <summary>
            /// Génération de 3 fausses instances de la classe Commentaire.
            /// <summary>//
            var commentaires = fakerCommentaire.Generate(3);

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Style.
            /// <summary>
            var fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => CapitalizeFirstLetter(f.Lorem.Word()));

            /// <summary>
            /// Génération de 3 fausses instances de la classe Style.
            /// <summary>//
            var styles = fakerStyle.Generate(2);

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.IdTitre, f => f.IndexFaker)
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Duree, f => f.Date.Timespan())
                .RuleFor(t => t.DateSortie, f => f.Date.Past())
                .RuleFor(t => t.DateCreation, f => f.Date.Recent())
                .RuleFor(t => t.NbLectures, f => f.Random.Number(1, 10000))
                .RuleFor(t => t.NbLikes, f => f.Random.Number(1, 1000))
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                .RuleFor(t => t.Chronique, f => f.Lorem.Paragraphs(10))
                .RuleFor(t => t.UrlJaquette, f => f.Image.PicsumUrl().ToString())
                .RuleFor(t => t.UrlEcoute, f => f.Internet.Url())
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                ;

            /// <summary>
            /// Génération de 1 fausse instance de la classe Titre.
            /// <summary>
            var titre = titreFaker.Generate();
            titre.Artiste = artiste;
            titre.Commentaires = commentaires;
            titre.Styles = styles;

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var titreModel = new TitreModel
            {
                Titre = titre,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(titreModel);
        }

        /// <summary>
        /// Action permettant d'afficher les titres liés à un style.
        /// </summary>
        /// <returns>Vue contenant la liste des titres liés au style.</returns>
        public IActionResult Style()
        {
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Artiste.
            /// <summary>
            var fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName());

            /// <summary>
            /// Génération de 1 fausse instance de la classe Artiste.
            /// <summary>//
            var artistes = fakerArtiste.Generate(150);

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Duree, f => TimeSpan.FromSeconds(f.Random.Number(60, 600)))
                .RuleFor(t => t.Artiste, f => f.PickRandom(artistes))
                .RuleFor(t => t.UrlJaquette, f => f.Image.PicsumUrl().ToString())
                ;

            /// <summary>
            /// Génération de 500 fausse instance de la classe Titre.
            /// <summary>
            var titres = titreFaker.Generate(500);

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
