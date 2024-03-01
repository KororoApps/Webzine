// <copyright file="ArtisteController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;
    using Webzine.Repository;
    using Webzine.Repository.Contracts;

    /// <summary>
    /// Contrôleur responsable de la gestion des artistes.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la biographie d'un artiste.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    public class ArtisteController : Controller
    {
        private readonly IArtisteRepository _artisteRepository;

        public ArtisteController(IArtisteRepository artisteRepository) 
        {
            this._artisteRepository = artisteRepository;
        }

        /// <summary>
        /// Action pour afficher les détails d'un artiste.
        /// </summary>
        /// <returns>Vue contenant les détails de l'artiste.</returns>
        public IActionResult Index(int id)
        {
            List<Artiste> artisteList = [this._artisteRepository.Find(id)];
            var artisteModel = new GroupeArtisteModel
            {
                Artistes = artisteList,
            };

            return this.View(artisteModel);
        }
    }
}
