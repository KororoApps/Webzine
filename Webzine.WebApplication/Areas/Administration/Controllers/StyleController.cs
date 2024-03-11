// <copyright file="StyleController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux styles dans la zone d'Administrationistration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des styles, la création, la suppression et l'édition d'un style.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    [Area("Administration")]
    public class StyleController(IStyleRepository styleRepository) : Controller
    {
        private IStyleRepository styleRepository = styleRepository;

        /// <summary>
        /// Affiche la liste des styles.
        /// </summary>
        /// <returns>Vue avec la liste des styles.</returns>
        public IActionResult Index(int numeroPage)
        {
            var titreToSkip = numeroPage * 15;

            // Création du modèle de vue contenant la liste de Styles.
            var styleModel = new GroupeStyleModel
            {
                Styles = this.styleRepository.FindStyles(titreToSkip, 15),
            };

            // Retour de la vue avec le modèle de vue contenant les styles générés.
            return this.View(styleModel);

        }



        /// <summary>
        /// Affiche la vue de création d'un nouveau style.
        /// </summary>
        /// <returns>Vue de création d'un nouveau style.</returns>
        public IActionResult Create()
        {
            // Retour de la vue pour la création d'un style.
            return this.View();
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la création d'un style.
        /// </summary>
        /// <param name="style">Le style à ajouter.</param>
        /// <returns>Redirection vers l'action Index après la création.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Style style)
        {
           if (!this.ModelState.IsValid)
            {
                // Traitement en cas de modèle non valide
                return this.View();
            }

           this.styleRepository.Add(style);
           return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Affiche la vue de suppression d'un style.
        /// </summary>
        /// <param name="id">L'identifiant du style à supprimer.</param>
        /// <returns>Vue de suppression d'un style.</returns>
        public IActionResult Delete(int id)
        {
            // Création du modèle de vue contenant le style à supprimer.
            var styleModel = new StyleModel
            {
                Style = this.styleRepository.Find(id),
            };

            // Retour de la vue avec le modèle de vue contenant le style généré.
            return this.View(styleModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la suppression d'un style.
        /// </summary>
        /// <param name="style">Le style à supprimer.</param>
        /// <returns>Redirection vers l'action Index après la suppression.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Style style)
        {

            this.styleRepository.Delete(style);

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Affiche la vue d'édition d'un style.
        /// </summary>
        /// /// <param name="id">L'identifiant du style à éditer.</param>
        /// <returns>Vue d'édition d'un style.</returns>
        public IActionResult Edit(int id)
        {
            // Création du modèle de vue contenant le style à éditer.
            var styleModel = new StyleModel
            {
                Style = this.styleRepository.Find(id),
            };

            // Retour de la vue avec le modèle de vue contenant le style généré.
            return this.View(styleModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer l'édition d'un style.
        /// </summary>
        /// <param name="style">Le style à éditer.</param>
        /// <returns>Redirection vers l'action Index après l'édition.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Style style)
        {
            if (!this.ModelState.IsValid)
            {
                // Création du modèle de vue contenant le style à éditer.
                var styleModel = new StyleModel
                {
                    Style = this.styleRepository.Find(style.IdStyle),
                };

                // Traitement en cas de modèle non valide
                return this.View(styleModel);
            }

            this.styleRepository.Update(style);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}