// <copyright file="ArtisteController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Bogus;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des artistes.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la biographie d'un artiste.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    public class ArtisteController : Controller
    {
        /// <summary>
        /// Action pour afficher les détails d'un artiste.
        /// </summary>
        /// <param name="nomArtiste">Nom de l'artiste.</param>
        /// <returns>Vue contenant les détails de l'artiste.</returns>
        public IActionResult Index(string nomArtiste)
        {

            /// <summary>
            /// Fonction pour mettre en majuscule la première lettre.
            /// <summary>
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
            var artisteFaker = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName())
                .RuleFor(a => a.Biographie, (f, u) => f.Lorem.Paragraph(40));

            /// <summary>
            /// Génération d'une fausse instance de la classe Artiste.
            /// <summary>
            var artiste = artisteFaker.Generate();

            /// <summary>
            /// Création d'un nombre aléatoire de titres.
            /// <summary>
            Random random = new();

            int randomNumber = random.Next(1, 11);

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.Libelle, (f, u) => CapitalizeFirstLetter(f.Lorem.Word()))
                .RuleFor(t => t.Duree, (f, u) => TimeSpan.FromMinutes(f.Random.Double(2, 4)))
                .RuleFor(t => t.Album, f => CapitalizeFirstLetter(f.Lorem.Word()))
                .RuleFor(t => t.UrlJaquette, (f, u) => f.Image.PicsumUrl());

            /// <summary>
            /// Génération d'une liste de titres.
            /// <summary>
            var fakeTitres = titreFaker.Generate(randomNumber);

            /// <summary>
            /// Attribution des titres à l'artiste.
            /// <summary>
            artiste.Titres = fakeTitres;

            /// <summary>
            /// Création du modèle de vue contenant l'artiste.
            /// <summary>
            var artisteModel = new ArtisteModel { Artiste = artiste };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les détails de l'artiste.
            /// <summary>
            return this.View(artisteModel);
        }
    }
}
