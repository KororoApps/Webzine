﻿// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
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

        /// <summary>
        /// Affiche la liste des titres.
        /// </summary>
        /// <returns>Vue avec la liste des titres générés.</returns>
        public IActionResult Index()
        {
            /// <summary>
            /// Génération d'une liste d'artistes.
            /// <summary>
            List<Artiste> artistes = DataFactory.GenerateFakeArtiste(10);

            /// <summary>
            /// Génération d'une liste de titres.
            /// <summary>
            List<Titre> titres = artistes.SelectMany(a => a.Titres).ToList();

            /// <summary>
            /// Tri de la liste des titres par date de création.
            /// <summary>
            var titresTries = titres.OrderByDescending(t => t.DateSortie).ToList();

            /// <summary>
            /// Création du modèle de vue contenant la liste de Titres.
            /// <summary>
            var titreModel = new GroupeTitreModel
            {
                Titres = titresTries,
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
            /// <summary>
            /// Génération d'une liste d'artistes.
            /// <summary>
            List<Artiste> artiste = DataFactory.GenerateFakeArtiste(1);

            /// <summary>
            /// Génération d'un titre.
            /// <summary>
            List<Titre> titres = artiste.SelectMany(a => a.Titres).ToList();
            Titre titre = titres.OrderBy(t => Guid.NewGuid()).FirstOrDefault();

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
        /// Action HTTP POST pour confirmer la suppression d'un titre.
        /// </summary>
        /// <param name="id">L'identifiant du titre à supprimer.</param>
        /// <returns>Redirection vers l'action Index après la suppression.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Affiche la vue de création d'un nouveau titre.
        /// </summary>
        /// <returns>Vue de création d'un nouveau titre.</returns>
        public IActionResult Create()
        {
            /// <summary>
            /// Génération d'une liste d'artistes.
            /// <summary>
            List<Artiste> artiste = DataFactory.GenerateFakeArtiste(1);

            /// <summary>
            /// Génération d'un titre.
            /// <summary>
            List<Titre> titres = artiste.SelectMany(a => a.Titres).ToList();
            Titre titre = titres.OrderBy(t => Guid.NewGuid()).FirstOrDefault();

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
        /// Action HTTP POST pour confirmer la création d'un titre.
        /// </summary>
        /// <returns>Redirection vers l'action Index après la création.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed()
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Affiche la vue d'édition d'un titre.
        /// </summary>
        /// <returns>Vue d'édition d'un titre.</returns>
        public IActionResult Edit()
        {
            /// <summary>
            /// Génération d'une liste d'artistes.
            /// <summary>
            List<Artiste> artiste = DataFactory.GenerateFakeArtiste(1);

            /// <summary>
            /// Génération d'un titre.
            /// <summary>
            List<Titre> titres = artiste.SelectMany(a => a.Titres).ToList();
            Titre titre = titres.OrderBy(t => Guid.NewGuid()).FirstOrDefault();

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
        /// Action HTTP POST pour confirmer l'édition d'un titre.
        /// </summary>
        /// <param name="id">L'identifiant du titre à éditer.</param>
        /// <returns>Redirection vers l'action Index après l'édition.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditConfirmed(int id)
        {
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}