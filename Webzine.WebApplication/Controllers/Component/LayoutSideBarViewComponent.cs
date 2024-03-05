// <copyright file="LayoutSideBarViewComponent.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers.Component
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="LayoutSideBarViewComponent"/>.
    /// </summary>
    public class LayoutSideBarViewComponent : ViewComponent
    {
        private readonly IStyleRepository styleRepository;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="LayoutSideBarViewComponent"/>.
        /// </summary>
        /// <param name="styleRepository">Le repository de styles.</param>
        public LayoutSideBarViewComponent(IStyleRepository styleRepository)
        {
            this.styleRepository = styleRepository ?? throw new ArgumentNullException(nameof(styleRepository));
        }

        /// <summary>
        /// Méthode invoquée lors de l'exécution du composant de vue.
        /// </summary>
        /// <returns>Une tâche asynchrone représentant l'opération.</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var styles = this.styleRepository.FindAll();

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