// <copyright file="HomeController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur principal gérant les actions liées à la page d'accueil.
    /// </summary>
    public class HomeController : Controller
    {

        /// <summary>
        /// Affiche la page d'accueil avec des données générées aléatoirement.
        /// </summary>
        /// <returns>Vue de la page d'accueil.</returns>
        public IActionResult Index()
        {
            // Génération d'une liste de titres.
            List<Titre> titres = DataFactory.Titres;

            // Tri de la liste des titres par date de création.
            var titresTries = titres.OrderByDescending(t => t.DateCreation).ToList();

            // Création du modèle de vue contenant la liste des titres.
            GroupeTitreModel groupeTitreModel = new()
            {
                Titres = titresTries,
            };

            // Retour de la vue avec le modèle de vue contenant les détails des titres.
            return this.View(groupeTitreModel);
        }
    }
}