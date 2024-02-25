﻿// <copyright file="LayoutSideBarViewComponent.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Views
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="LayoutSideBarViewComponent"/>.
    /// </summary>
    public class LayoutSideBarViewComponent : ViewComponent
    {
        /// <summary>
        /// Méthode invoquée lors de l'exécution du composant de vue.
        /// </summary>
        /// <returns>Une tâche asynchrone représentant l'opération.</returns>

        public async Task<IViewComponentResult> InvokeAsync()
        {
            /// <summary>
            /// // Récupération des styles depuis la factory.
            /// </summary>
            List<Style> styles = DataFactory.GenerateFakeStyles(25);

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var styleModel = new GroupeStyleModel
            {
                Styles = styles,
            };
            /// <summary>
            /// Passage du modèle à la vue
            /// <summary>
            var vm = styleModel;

            return this.View(vm);
        }
    }
}