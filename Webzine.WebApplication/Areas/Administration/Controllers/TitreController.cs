﻿// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Controller responsable de la gestion des opérations liées aux titres dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des titres, la création, la suppression et l'édition d'un titre.
    /// Il utilise soit le générateur de fausses données Bogus pour simuler des données, soit des données Spotify en fonction du Seeder sélectionné.
    /// </remarks>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="TitreController"/>.
    /// </remarks>
    /// <param name="titreRepository">Le repository des titres utilisé par le controller.</param>
    /// <param name="styleRepository">Le repository des styles utilisé par le controller.</param>
    /// <param name="artisteRepository">Le repository des artistes utilisé par le controller.</param>
    [Area("Administration")]
    public class TitreController(ITitreRepository titreRepository, IStyleRepository styleRepository, IArtisteRepository artisteRepository) : Controller
    {
        private readonly ITitreRepository titreRepository = titreRepository;
        private readonly IStyleRepository styleRepository = styleRepository;
        private readonly IArtisteRepository artisteRepository = artisteRepository;

        /// <summary>
        /// Affiche la liste des titres.
        /// </summary>
        /// <param name="numeroPage">Le numéro de la page à afficher.</param>
        /// <returns>Retourne la vue avec la liste des titres générés.</returns>
        public IActionResult Index(int numeroPage)
        {
            var titreToSkip = numeroPage * 15;

            var titreModel = new TitreModel
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
        /// <returns>Retourne la vue de suppression d'un titre.</returns>
        public IActionResult Delete(int id)
        {
            var titre = this.titreRepository.Find(id);

            if (titre == null)
            {
                return new StatusCodeResult(404);
            }

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
            this.titreRepository.Delete(titre);
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Affiche la vue de création d'un nouveau titre.
        /// </summary>
        /// <returns>Retourne la vue de création d'un nouveau titre.</returns>
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
        /// <returns>Retourne la vue d'édition d'un titre.</returns>
        public IActionResult Edit(int id)
        {
            var titre = this.titreRepository.Find(id);

            if (titre == null)
            {
                return new StatusCodeResult(404);
            }

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
        /// Action résultante HTTP POST pour la modification d'un titre.
        /// </summary>
        /// <param name="titre">Le titre à modifier.</param>
        /// <param name="styleIds">La liste des identifiants des styles associés au titre.</param>
        /// <returns>La vue de modification du titre ou la redirection vers l'action Index si la modification est réussie.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            [Bind("IdTitre", "IdArtiste", "Artiste", "Commentaires", "Styles", "Libelle", "Duree", "DateSortie","DateCreation", "Album", "Chronique", "UrlJaquette", "UrlEcoute", "NbLikes", "NbLectures")]
            Titre titre, List<int> styleIds)
        {
            Titre titreAEditer = this.titreRepository.Find(titre.IdTitre);

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

            titreAEditer.Styles = stylesById.ToList();
            titreAEditer.Artiste = artiste;
            titreAEditer.Libelle = titre.Libelle;
            titreAEditer.Album = titre.Album;
            titreAEditer.Chronique = titre.Chronique;
            titreAEditer.DateSortie = titre.DateSortie;
            titreAEditer.Duree = titre.Duree;
            titreAEditer.UrlJaquette = titre.UrlJaquette;
            titreAEditer.UrlEcoute = titre.UrlEcoute;

            this.titreRepository.Update(titreAEditer);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}