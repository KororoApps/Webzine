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
    /// </remarks>
    public class ArtisteController(IArtisteRepository artisteRepository) : Controller
    {
        private readonly IArtisteRepository artisteRepository = artisteRepository;

        /// <summary>
        /// Action permettant d'afficher les artistes liés à un groupe.
        /// </summary>
        /// <param name="id">Identifiant du groupe d'artistes.</param>
        /// <returns>Vue contenant la liste des artistes liés au groupe.</returns>
        public IActionResult Index(int id)
        {
            var artisteModel = new ArtisteModel
            {
                Artiste = this.artisteRepository.Find(id),
            };

            return this.View(artisteModel);
        }
    }


   
}



