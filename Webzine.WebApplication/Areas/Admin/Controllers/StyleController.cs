// <copyright file="StyleController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers

{
    using Bogus;
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
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
            /// Fonction pour mettre en majuscule la première lettre.
            /// <summary>// Fonction pour mettre en majuscule la première lettre
            static string CapitalizeFirstLetter(string input)
            {
                if (string.IsNullOrEmpty(input))
                {
                    return input;
                }

                return char.ToUpper(input[0]) + input[1..];
            }

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Style.
            /// </summary>
            var fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => CapitalizeFirstLetter(f.Lorem.Word()));

            /// <summary>
            /// Génération de 20 fausses instances de la classe Style.
            /// </summary>
            var styles = fakerStyle.Generate(20);

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
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Style.
            /// </summary>
            var fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => f.Random.Word());

            /// <summary>
            /// Génération de 1 fausse instance de la classe Style.
            /// </summary>
            var style = fakerStyle.Generate();

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
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Style.
            /// </summary>
            var fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => f.Random.Word());

            /// <summary>
            /// Génération de 1 fausse instance de la classe Style.
            /// </summary>
            var style = fakerStyle.Generate();

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