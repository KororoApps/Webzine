// <copyright file="ArtisteController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
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

        private readonly IArtisteRepository artisteRepository;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ArtisteController"/>.
        /// </summary>
        /// <param name="artisteRepository">Le repository des artistes à injecter.</param>
        public ArtisteController(IArtisteRepository artisteRepository)
        {
            this.artisteRepository = artisteRepository;
        }

        /// <summary>
        /// Action pour afficher la liste des artistes.
        /// </summary>
        /// <returns>Vue contenant la liste des artistes.</returns>
        public IActionResult Index(int numeroPage)
        {
            var titreToSkip = numeroPage * 15;

            var artisteModel = new GroupeArtisteModel
            {
                Artistes = this.artisteRepository.FindArtistes(titreToSkip, 15),
                NumeroPage = numeroPage,
            };

            return this.View(artisteModel);
        }

        /// <summary>
        /// Action pour afficher la vue de suppression d'un artiste.
        /// </summary>
        /// <param name="id">L'identifiant de l'artiste à supprimer.</param>
        /// <returns>Vue de suppression d'un artiste.</returns>
        public IActionResult Delete(int id)
        {
            var artiste = this.artisteRepository.Find(id);

            var artisteModel = new ArtisteModel
            {
                Artiste = artiste,
            };

            return this.View(artisteModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la suppression d'un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à supprimer.</param>
        /// <returns>Redirection vers l'action Index après la suppression.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Artiste artiste)
        {
            this.artisteRepository.Delete(artiste);

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Action pour afficher la vue de création d'un artiste.
        /// </summary>
        /// <returns>Vue de création d'un artiste.</returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la création d'un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à ajouter.</param>
        /// <returns>Redirection vers l'action Index après la création.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Artiste artiste)
        {
            if (!this.ModelState.IsValid)
            {
                // Traitement en cas de modèle non valide
                return this.View();
            }

            this.artisteRepository.Add(artiste);
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Action pour afficher la vue d'édition d'un artiste.
        /// </summary>
        /// <param name="id">L'identifiant de l'artiste à éditer.</param>
        /// <returns>Vue d'édition d'un artiste.</returns>
        public IActionResult Edit(int id)
        {
            var artiste = this.artisteRepository.Find(id);

            var artisteModel = new ArtisteModel
            {
                Artiste = artiste,
            };

            return this.View(artisteModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer l'édition d'un artiste.
        /// </summary>
        /// <param name="artiste">L'artiste à éditer.</param>
        /// <returns>Redirection vers l'action Index après l'édition.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Artiste artiste)
        {
            if (!this.ModelState.IsValid)
            {
                // Création du modèle de vue contenant le style à éditer.
                var artisteModel = new ArtisteModel
                {
                    Artiste = this.artisteRepository.Find(artiste.IdArtiste),
                };

                // Traitement en cas de modèle non valide
                return this.View(artisteModel);
            }

            this.artisteRepository.Update(artiste);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}