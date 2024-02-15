// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.Factories;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux titres dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des titres, la création, la suppression et l'édition d'un titre.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    [Area("Admin")]
    public class TitreController : Controller
    {
        private readonly TitreFactory titreFactory;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TitreController"/>.
        /// </summary>
        public TitreController()
        {
            this.titreFactory = new TitreFactory();
        }

        /// <summary>
        /// Affiche la liste des titres.
        /// </summary>
        /// <returns>Vue avec la liste des titres générés.</returns>
        public IActionResult Index()
        {
            var titres = this.titreFactory.CreateTitres(150, 3);

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

        /// <summary>
        /// Affiche la vue de suppression d'un titre.
        /// </summary>
        /// <returns>Vue de suppression d'un titre.</returns>
        public IActionResult Delete()
        {
            Titre titre = this.titreFactory.CreateTitre(3);

            /// <summary>
            /// Création du modèle de vue contenant un Titre.
            /// <summary>
            var titreModel = new TitreModel
            {
                Titre = titre,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant le titre généré.
            /// <summary>
            return this.View(titreModel);
        }

        /// <summary>
        /// Affiche la vue de création d'un nouveau titre.
        /// </summary>
        /// <returns>Vue de création d'un nouveau titre.</returns>
        public IActionResult Create()
        {
            Titre titre = this.titreFactory.CreateTitre(20);

            /// <summary>
            /// Création du modèle de vue contenant un Titre.
            /// <summary>
            var titreModel = new TitreModel
            {
                Titre = titre,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant le titre généré afin d'avoir accès aux styles.
            /// <summary>
            return this.View(titreModel);
        }

        /// <summary>
        /// Affiche la vue d'édition d'un titre.
        /// </summary>
        /// <returns>Vue d'édition d'un titre.</returns>
        public IActionResult Edit()
        {
            Titre titre = this.titreFactory.CreateTitre(17);

            /// <summary>
            /// Création du modèle de vue contenant un Titre.
            /// <summary>
            var titreModel = new TitreModel
            {
                Titre = titre,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant le titre généré.
            /// <summary>
            return this.View(titreModel);
        }


    }
}