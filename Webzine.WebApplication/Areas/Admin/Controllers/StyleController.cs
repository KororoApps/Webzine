﻿// <copyright file="StyleController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.Factories;
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
        private readonly StyleFactory styleFactory;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="StyleController"/>.
        /// </summary>
        public StyleController()
        {
            this.styleFactory = new StyleFactory();
        }

        /// <summary>
        /// Affiche la liste des styles.
        /// </summary>
        /// <returns>Vue avec la liste des styles.</returns>
        public IActionResult Index()
        {
            var styles = this.styleFactory.CreateStyles(25);

            /// <summary>
            /// Création du modèle de vue contenant la liste de styles.
            /// </summary>
            var styleModel = new GroupeStyleModel
            {
                Styles = styles,
            };

            return this.View(styleModel);
        }

        /// <summary>
        /// Affiche la vue de création d'un nouveau style.
        /// </summary>
        /// <returns>Vue de création d'un nouveau style.</returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Affiche la vue de suppression d'un style.
        /// </summary>
        /// <returns>Vue de suppression d'un style.</returns>
        public IActionResult Delete()
        {
            Style style = this.styleFactory.CreateStyle();

            /// <summary>
            /// Création du modèle de vue contenant le style à supprimer.
            /// </summary>
            var styleModel = new StyleModel
            {
                Style = style,
            };

            return this.View(styleModel);
        }

        /// <summary>
        /// Affiche la vue d'édition d'un style.
        /// </summary>
        /// <returns>Vue d'édition d'un style.</returns>
        public IActionResult Edit()
        {
            Style style = this.styleFactory.CreateStyle();

            /// <summary>
            /// Création du modèle de vue contenant le style à éditer.
            /// </summary>
            var styleModel = new StyleModel
            {
                Style = style,
            };

            return this.View(styleModel);
        }
    }
}