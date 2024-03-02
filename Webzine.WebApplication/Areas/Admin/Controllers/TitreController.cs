// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux titres dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des titres, la création, la suppression et l'édition d'un titre.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="TitreController"/>.
    /// </remarks>
    /// <param name="titreRepository">Le repository des titres utilisé par le contrôleur.</param>
    /// <param name="styleRepository">Le repository des styles utilisé par le contrôleur.</param>
    /// <param name="artisteRepository">Le repository des artistes utilisé par le contrôleur.</param>
    [Area("Admin")]
    public class TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository, IArtisteRepository artisteRepository) : Controller
    {
        private readonly ITitreRepository titreRepository = titreRepository;
        private readonly IStyleRepository styleRepository = styleRepository;
        private readonly IArtisteRepository artisteRepository = artisteRepository;

        /// <summary>
        /// Affiche la liste des titres.
        /// </summary>
        /// <returns>Vue avec la liste des titres générés.</returns>
        public IActionResult Index()
        {
            // Génération d'une liste de titres.
            List<Titre> titres = DataFactory.Titres;

            // Tri de la liste des titres par date de création.
            var titresTries = titres.OrderByDescending(t => t.DateSortie).ToList();

            // Création du modèle de vue contenant la liste de Titres.
            var titreModel = new GroupeTitreModel
            {
                Titres = titresTries,
            };

            // Retour de la vue avec le modèle de vue contenant les titres générés.
            return this.View(titreModel);
        }

        /// <summary>
        /// Affiche la vue de suppression d'un titre.
        /// </summary>
        /// <param name="id">L'identifiant du titre à trouver.</param>
        /// <returns>Vue de suppression d'un titre.</returns>
        public IActionResult Delete(int id)
        {

            var titre = this.titreRepository.Find(id);

            var titreModel = new TitreModel
            {
                Titre = titre,
            };

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
            this.titreRepository.Delete(this.titreRepository.Find(id));
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Affiche la vue de création d'un nouveau titre.
        /// </summary>
        /// <returns>Vue de création d'un nouveau titre.</returns>
        public IActionResult Create()
        {
            // Génération d'une liste de styles.
            var styles = this.styleRepository.FindAll();

            // Génération d'une liste d'artistes.
            var artistes = this.artisteRepository.FindAll();

            // Création du modèle de vue contenant un Titre.
            var titreModel = new TitreModel
            {
                Styles = styles,
                Artistes = artistes,
            };

            // Retour de la vue avec le modèle de vue contenant le titre généré.
            return this.View(titreModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la création d'un titre.
        /// </summary>
        /// <param name="titre">L'entité Titre à créer.</param>
        /// <param name="styleIds">L'identifiant du/des style(s) à créer au titre.</param>
        /// <returns>Redirection vers l'action Index après la création.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(Titre titre, List<int> styleIds)
        {
           IEnumerable<Style> styles = this.styleRepository.FindByIds(styleIds);
           Artiste artiste = this.artisteRepository.Find(titre.Artiste.IdArtiste);
           titre.Styles = styles.ToList();
           titre.Artiste = artiste;
           this.titreRepository.Add(titre);
           return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Affiche la vue d'édition d'un titre.
        /// </summary>
        /// <param name="id">L'identifiant du titre à éditer.</param>
        /// <returns>Vue d'édition d'un titre.</returns>
        public IActionResult Edit(int id)
        {
            var titre = this.titreRepository.Find(id);

            // Génération d'une liste d'artistes.
            var styles = this.styleRepository.FindAll();

            // Création du modèle de vue contenant un Titre.
            var titreModel = new TitreModel
            {
                Styles = styles,
                Titre = titre,
            };

            // Retour de la vue avec le modèle de vue contenant le titre généré.
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