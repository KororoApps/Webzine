// <copyright file="RechercheController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Contrôleur principal gérant les actions liées à la page d'accueil.
    /// </summary>
    /// <param name="titreRepository">Le repository des titres.</param>
    /// <param name="artisteRepository">Le repository des artistes.</param>
    public class RechercheController(ITitreRepository titreRepository, IArtisteRepository artisteRepository) : Controller
    {
        private readonly ITitreRepository titreRepository = titreRepository;
        private readonly IArtisteRepository artisteRepository = artisteRepository;

        /// <summary>
        /// Affiche la page d'accueil avec des données générées aléatoirement.
        /// </summary>
        /// <param name="recherche">Le terme de recherche saisi dans le formulaire.</param>
        /// <returns>Vue de la page d'accueil.</returns>
        [HttpPost]
        public IActionResult Index(string recherche)
        {
            // Création du modèle de vue contenant la liste de titres filtrés.
            var rechercheModel = new RechercheModel
            {
                Artistes = this.artisteRepository.Search(recherche),
                Titres = this.titreRepository.Search(recherche),
                Recherche = recherche,
            };

            // Retour de la vue avec le modèle de vue contenant les titres filtrés.
            return this.View(rechercheModel);
        }
    }
}