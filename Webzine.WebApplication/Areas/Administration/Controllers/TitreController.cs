// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux titres dans la zone d'Administrationistration.
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
    [Area("Administration")]
    public class TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository, IArtisteRepository artisteRepository) : Controller
    {
        private readonly ITitreRepository titreRepository = titreRepository;
        private readonly IStyleRepository styleRepository = styleRepository;
        private readonly IArtisteRepository artisteRepository = artisteRepository;

        /// <summary>
        /// Affiche la liste des titres.
        /// </summary>
        /// <returns>Vue avec la liste des titres générés.</returns>
        /// <param name="numeroPage">Indique le nunméro de page sur lequel nous sommes.</param>
        public IActionResult Index(int numeroPage)
        {
            var titreToSkip = numeroPage * 15;

            var titreModel = new GroupeTitreModel
            {
                Titres = this.titreRepository.FindTitres(titreToSkip, 15),
                NumeroPage = numeroPage,
            };

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
        /// <param name="titre">Le titre à supprimer.</param>
        /// <returns>Redirection vers l'action Index après la suppression.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Titre titre)
        {
            this.titreRepository.Delete(this.titreRepository.Find(titre.IdTitre));
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
        public IActionResult Create(Titre titre, List<int> styleIds)
        {
            // Styles sélectionnés pour le titre
            IEnumerable<Style> stylesById = this.styleRepository.FindByIds(styleIds);

            if (!this.ModelState.IsValid)
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
                    Titre = titre,
                    StylesIds = stylesById,
                };

                // Traitement en cas de modèle non valide
                return this.View(titreModel);
            }

            Artiste artiste = this.artisteRepository.FindByName(titre.Artiste.Nom);

            titre.Styles = stylesById.ToList();
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

            // Génération d'une liste de styles.
            var styles = this.styleRepository.FindAll();

            // Génération d'une liste d'artistes.
            var artistes = this.artisteRepository.FindAll();

            // Création du modèle de vue contenant un Titre.
            var titreModel = new TitreModel
            {
                Styles = styles,
                Titre = titre,
                Artistes = artistes,
                StylesIds = titre.Styles,
            };

            // Retour de la vue avec le modèle de vue contenant le titre généré.
            return this.View(titreModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer l'édition d'un titre.
        /// </summary>
        /// <param name="titre">Le titre à éditer.</param>
        /// <returns>Redirection vers l'action Index après l'édition.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Titre titre, List<int> styleIds)
        {
            // Styles sélectionnés pour le titre
            IEnumerable<Style> stylesById = this.styleRepository.FindByIds(styleIds);

            if (!this.ModelState.IsValid)
            {
                // Génération d'une liste de styles.
                var styles = this.styleRepository.FindAll();

                // Génération d'une liste d'artistes.
                var artistes = this.artisteRepository.FindAll();

                // Création du modèle de vue contenant le style à éditer.
                var titreModel = new TitreModel
                {
                    Styles = styles,
                    Artistes = artistes,
                    Titre = titre,
                    StylesIds = stylesById,
                };

                // Traitement en cas de modèle non valide
                return this.View(titreModel);
            }

            Artiste artiste = this.artisteRepository.FindByName(titre.Artiste.Nom);

            titre.Styles = stylesById.ToList();
            titre.Artiste = artiste;

            this.titreRepository.Update(titre);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}