// <copyright file="ArtisteController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;
 

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux artistes dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des artistes, la création, la suppression et l'édition d'un artiste.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    [Area("Admin")]
    public class ArtisteController : Controller
    {
        /// <summary>
        /// Action pour afficher la liste des artistes.
        /// </summary>
        /// <returns>Vue contenant la liste des artistes.</returns>
        public IActionResult Index()
        {
            /// <summary>
            /// Génération d'une liste d'artistes.
            /// <summary>
           List<Artiste> artistes = DataFactory.Artistes;

            /// <summary>
            /// Tri de la liste des artistes par nom.
            /// <summary>
            var artistesTries = artistes.OrderBy(a => a.Nom).ToList();

            /// <summary>
            /// Création du modèle de vue contenant la liste d'Artistes.
            /// <summary>
            var artisteModel = new GroupeArtisteModel
            {
                Artistes = artistesTries,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les artistes générés.
            /// <summary>
            return this.View(artisteModel);
        }

        /// <summary>
        /// Action pour afficher la vue de suppression d'un artiste.
        /// </summary>
        /// <returns>Vue de suppression d'un artiste.</returns>
        public IActionResult Delete()
        {
            /// <summary>
            /// Génération d'un artiste.
            /// <summary>
            List<Artiste> artistes = DataFactory.Artistes;
            Artiste artiste = artistes.OrderBy(t => Guid.NewGuid()).FirstOrDefault();

            /// <summary>
            /// Création du modèle de vue contenant un artiste.
            /// <summary>
            var artisteModel = new ArtisteModel
            {
                Artiste = artiste,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les détails de l'artiste.
            /// <summary>
            return this.View(artisteModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la suppression d'un artiste.
        /// </summary>
        /// <param name="id">L'identifiant de l'artiste à supprimer.</param>
        /// <returns>Redirection vers l'action Index après la suppression.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Action pour afficher la vue de création d'un artiste.
        /// </summary>
        /// <returns>Vue de création d'un artiste.</returns>
        public IActionResult Create()
        {
            /// <summary>
            /// Retour de la vue pour la création d'un artiste.
            /// <summary>
            return this.View();
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la création d'un artiste.
        /// </summary>
        /// <returns>Redirection vers l'action Index après la création.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed()
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Action pour afficher la vue d'édition d'un artiste.
        /// </summary>
        /// <returns>Vue d'édition d'un artiste.</returns>
        public IActionResult Edit()
        {
            /// <summary>
            /// Génération d'un artiste.
            /// <summary>
            List<Artiste> artistes = DataFactory.Artistes;
            Artiste artiste = artistes.OrderBy(t => Guid.NewGuid()).FirstOrDefault();

            /// <summary>
            /// Création du modèle de vue contenant un artiste.
            /// <summary>
            var artisteModel = new ArtisteModel
            {
                Artiste = artiste,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les détails de l'artiste.
            /// <summary>
            return this.View(artisteModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer l'édition d'un artiste.
        /// </summary>
        /// <param name="id">L'identifiant de l'artiste à éditer.</param>
        /// <returns>Redirection vers l'action Index après l'édition.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditConfirmed(int id)
        {
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}