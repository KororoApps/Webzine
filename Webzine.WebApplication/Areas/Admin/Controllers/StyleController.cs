// <copyright file="StyleController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux styles dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des styles, la création, la suppression et l'édition d'un style.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    [Area("Admin")]
    public class StyleController : Controller
    {
        /// <summary>
        /// Affiche la liste des styles.
        /// </summary>
        /// <returns>Vue avec la liste des styles.</returns>
        public IActionResult Index()
        {
            /// <summary>
            /// Génération d'une liste de styles.
            /// <summary>
            List<Style> styles = DataFactory.GenerateFakeStyles(50);

            /// <summary>
            /// Tri de la liste des styles par nom.
            /// <summary>
            var stylesTries = styles.OrderBy(s => s.Libelle).ToList();

            /// <summary>
            /// Création du modèle de vue contenant la liste de Styles.
            /// </summary>
            var styleModel = new GroupeStyleModel
            {
                Styles = stylesTries,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les styles générés.
            /// <summary>
            return this.View(styleModel);
        }

        /// <summary>
        /// Affiche la vue de création d'un nouveau style.
        /// </summary>
        /// <returns>Vue de création d'un nouveau style.</returns>
        public IActionResult Create()
        {
            /// <summary>
            /// Retour de la vue pour la création d'un style.
            /// <summary>
            return this.View();
        }

        /// <summary>
        /// Affiche la vue de suppression d'un style.
        /// </summary>
        /// <returns>Vue de suppression d'un style.</returns>
        public IActionResult Delete()
        {
            /// <summary>
            /// Génération d'un style.
            /// <summary>
            List<Style> styles = DataFactory.GenerateFakeStyles(50);
            Style style = styles.OrderBy(t => Guid.NewGuid()).FirstOrDefault();


            /// <summary>
            /// Création du modèle de vue contenant le style à supprimer.
            /// </summary>
            var styleModel = new StyleModel
            {
                Style = style,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant le style généré.
            /// <summary>
            return this.View(styleModel);
        }

        /// <summary>
        /// Affiche la vue d'édition d'un style.
        /// </summary>
        /// <returns>Vue d'édition d'un style.</returns>
        public IActionResult Edit()
        {
            /// <summary>
            /// Génération d'un style.
            /// <summary>
            List<Style> styles = DataFactory.GenerateFakeStyles(50);
            Style style = styles.OrderBy(t => Guid.NewGuid()).FirstOrDefault();

            /// <summary>
            /// Création du modèle de vue contenant le style à éditer.
            /// </summary>
            var styleModel = new StyleModel
            {
                Style = style,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant le style généré.
            /// <summary>
            return this.View(styleModel);
        }
    }
}