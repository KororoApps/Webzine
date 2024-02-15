// <copyright file="DashboardController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.WebApplication.Shared.Factories;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion du tableau de bord administratif.
    /// </summary>
    [Area("Admin")]
    public class DashboardController : Controller
    {

        private readonly TitreFactory titreFactory;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DashboardController"/>.
        /// </summary>
        public DashboardController()
        {
            this.titreFactory = new TitreFactory();
        }

        /// <summary>
        ///   Affiche la page d'index du tableau de bord administratif.
        /// </summary>
        /// <returns>Vue avec le modèle de vue contenant les titres générés.</returns>
        public IActionResult Index()
        {
            var titres = this.titreFactory.CreateTitres(15, 3);

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var titreModel = new GroupeTitreModel
            {
                Titres = titres,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les titres générés.
            /// <summary>
            return this.View(titreModel);
        }
    }
}