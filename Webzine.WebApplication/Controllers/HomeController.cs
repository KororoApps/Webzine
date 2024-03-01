// <copyright file="HomeController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur principal gérant les actions liées à la page d'accueil.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ITitreRepository _titreRepository;

        public HomeController(ITitreRepository titreRepository)
        {
            _titreRepository = titreRepository;
        }
        /// <summary>
        /// Affiche la page d'accueil.
        /// </summary>
        /// <returns>Vue de la page d'accueil.</returns>
        public IActionResult Index()
        {
            // Création du modèle de vue contenant la liste des titres.
            GroupeTitreModel groupeTitreModel = new()
            {
                Titres = this._titreRepository.FindAll(),
            };

            // Retour de la vue avec le modèle de vue contenant les détails des titres.
            return this.View(groupeTitreModel);
        }
    }
}