// <copyright file="ArtisteController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des artistes.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la biographie d'un artiste.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// <param name="artisteRepository">Le repository des artistes à injecter.</param>
    /// </remarks>
    public class ArtisteController(IArtisteRepository artisteRepository) : Controller
    {
        private readonly IArtisteRepository artisteRepository = artisteRepository;

        /// <summary>
        /// Méthode d'action responsable de l'affichage des détails d'un artiste.
        /// </summary>
        /// <param name="nom">Le nom de l'artiste à afficher.</param>
        /// <returns>Une vue contenant les détails de l'artiste.</returns>
        public IActionResult Index(string nom)
        {

            var artisteModel = new ArtisteModel
            {
                Artiste = this.artisteRepository.FindByName(nom),
            };

            return this.View(artisteModel);
        }
    }
}