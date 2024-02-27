// <copyright file="LayoutSideBarViewComponent.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers.Component
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
            // Récupération des styles depuis la factory.
            List<Style> styles = DataFactory.Styles;

            // Création du modèle de vue contenant la liste de Titres.
            var styleModel = new GroupeStyleModel
            {
                Styles = styles,
            };

            // Passage du modèle à la vue
            var vm = styleModel;

            return View(vm);
        }
    }
}