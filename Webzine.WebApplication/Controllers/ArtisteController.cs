// <copyright file="ArtisteController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Bogus;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.Factories;
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
        private readonly ArtisteFactory artisteFactory;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ArtisteController"/>.
        /// </summary>
        public ArtisteController()
        {
            this.artisteFactory = new ArtisteFactory();
        }

        /// <summary>
        /// Action pour afficher les détails d'un artiste.
        /// </summary>
        /// <param name="nomArtiste">Nom de l'artiste.</param>
        /// <returns>Vue contenant les détails de l'artiste.</returns>
        public IActionResult Index()
        {
            Artiste artiste = this.artisteFactory.CreateArtiste();

            /// <summary>
            /// Création du modèle de vue contenant la liste de Artiste.
            /// <summary>
            var artisteModel = new ArtisteModel
            {
                Artiste = artiste,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les détails de l'artiste.
            /// <summary>
            return this.View(artisteModel);
        }
    }
}
