// <copyright file="ArtisteController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Bogus;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.Factories;
    using Webzine.WebApplication.Shared.Interfaces;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux artistes dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des artiste, la création, la suppression et l'édition d'un artiste.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>

    [Area("Admin")]
    public class ArtisteController : Controller
    {
        private readonly IArtisteFactory artisteFactory;

        public ArtisteController(IArtisteFactory iArtisteFactory)
        {
            artisteFactory = iArtisteFactory;
        }

        /// <summary>
        /// Action pour afficher la liste des artistes.
        /// </summary>
        /// <returns>Vue contenant la liste des artistes.</returns>
        public IActionResult Index()
        {
            var artistes = this.artisteFactory.CreateArtistes(150);

            /// <summary>
            /// Création du modèle de vue contenant la liste de Artiste.
            /// <summary>
            var artisteModel = new GroupeArtisteModel
            {
                Artistes = artistes,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(artisteModel);
        }

        /// <summary>
        /// Action pour afficher la vue de suppression d'un artiste.
        /// </summary>
        /// <returns>Vue de suppression d'un artiste.</returns>
        public IActionResult Delete()
        {
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
            /// Création du modèle de vue contenant la liste de Artiste.
            /// <summary>
            var artisteModel = new ArtisteModel
            {
                Artiste = artiste,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(artisteModel);
        }

        /// <summary>
        /// Action pour afficher la vue de création d'un artiste.
        /// </summary>
        /// <returns>Vue de création d'un artiste.</returns>
        public IActionResult Create()
        {
            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View();
        }

        /// <summary>
        /// Action pour afficher la vue d'édition d'un artiste.
        /// </summary>
        /// <returns>Vue d'édition d'un artiste.</returns>
        public IActionResult Edit()
        {
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Artiste.
            /// <summary>
            var fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName())
                .RuleFor(a => a.Biographie, (f, u) => f.Lorem.Paragraph());

            /// <summary>
            /// Génération de 1 fausse instance de la classe Artiste.
            /// <summary>//
            var artiste = fakerArtiste.Generate();

            /// <summary>
            /// Création du modèle de vue contenant la liste de Artiste.
            /// <summary>
            var artisteModel = new ArtisteModel
            {
                Artiste = artiste,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(artisteModel);
        }
    }
}