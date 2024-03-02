// <copyright file="HomeController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur principal gérant les actions liées à la page d'accueil.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="HomeController"/>.
    /// </remarks>
    /// <param name="titreRepository">Le repository des titres.</param>
    public class HomeController(ITitreRepository titreRepository) : Controller
    {
        private readonly ITitreRepository titreRepository = titreRepository;

        /// <summary>
        /// Affiche la page d'accueil.
        /// </summary>
        /// <returns>Vue de la page d'accueil.</returns>
        public IActionResult Index()
        {

            // Création du modèle de vue contenant la liste des titres.
            GroupeTitreModel groupeTitreModel = new()
            {
                Titres = this.titreRepository.FindAll(),
                TitresPopulaires = this.titreRepository.FindTitresLesPlusLike(),
                ParutionChroniqueTitre = this.titreRepository.ParutionChroniqueTitres(),
            };

            // Retour de la vue avec le modèle de vue contenant les détails des titres.
            return this.View(groupeTitreModel);
        }
    }
}