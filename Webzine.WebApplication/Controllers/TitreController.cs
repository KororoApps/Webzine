﻿// <copyright file="TitreController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Controller responsable de la gestion des titres.
    /// </summary>
    /// <remarks>
    /// Ce controller gère l'affichage de la chronique d'un titre.
    /// </remarks>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="TitreController"/>.
    /// </remarks>
    /// <param name="titreRepository">Le repository des titres utilisé par le controller.</param>
    /// <param name="commentaireRepository">Le repository des commentaires utilisé par le controller.</param>
    public class TitreController(ITitreRepository titreRepository, ICommentaireRepository commentaireRepository) : Controller
    {
        private readonly ITitreRepository titreRepository = titreRepository;
        private readonly ICommentaireRepository commentaireRepository = commentaireRepository;

        /// <summary>
        /// Action qui affiche la liste des titres.
        /// </summary>
        /// <param name="idTitre">Identifiant du titre à afficher.</param>
        /// <returns>Retourne la vue avec la liste des titres générés.</returns>
        public IActionResult Index(int idTitre)
        {
            // Génération d'une liste de commentaires.
            var commentaires = this.commentaireRepository.FindCommentairesByIdTitre(idTitre);

            Titre titre = this.titreRepository.Find(idTitre);

            if (titre == null)
            {
                return new StatusCodeResult(404);
            }

            this.titreRepository.IncrementNbLectures(titre);

            // Création du modèle de vue contenant un titre.
            var titreModel = new TitreModel
            {
                Titre = titre,
                Commentaires = commentaires,
            };

            // Retour de la vue avec le modèle de vue contenant le titre généré.
            return this.View(titreModel);
        }

        /// <summary>
        /// Méthode d'action responsable de l'ajout d'un "like" à un titre.
        /// </summary>
        /// <param name="titre">Le titre auquel ajouter le "like".</param>
        /// <returns>Redirection vers la vue des détails du titre ou une action spécifiée.</returns>
        [HttpPost]
        public IActionResult Liker(Titre titre)
        {

            // Incrémentez le nombre de likes
            this.titreRepository.IncrementNbLikes(titre);

            // Redirigez ou retournez à la vue selon vos besoins
            return this.RedirectToAction(nameof(this.Index), new { idTitre = titre.IdTitre });
        }

        /// <summary>
        /// Action permettant d'afficher les titres liés à un style.
        /// </summary>
        /// /// <param name="style">Libellé du style.</param>
        /// <returns>Vue contenant la liste des titres liés au style.</returns>
        public IActionResult Style(string style)
        {
            IEnumerable<Titre> titres = this.titreRepository.SearchByStyle(style);

            var titreModel = new TitreModel
            {
                Titres = titres,
                Libelle = style,
            };

            if (titres.Count() == 0)
            {
                return new StatusCodeResult(404);
            }

            // Retour de la vue avec le modèle de vue contenant les titres générés en fonction des styles.
            return this.View(titreModel);
        }

        /// <summary>
        /// Action pour afficher la vue de création d'un artiste.
        /// </summary>
        /// <returns>Vue de création d'un artiste.</returns>
        /// /// <param name="titre">Titre lié au commentaire.</param>
        public IActionResult Commenter(Titre titre)
        {
            return this.RedirectToAction(nameof(this.Index), new { idTitre = titre.IdTitre });
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la création d'un commentaire.
        /// </summary>
        /// <param name="commentaire">L'entité Commentaire à créer.</param>
        /// <param name="idTitre">Id du titre lié au commentaire.</param>
        /// <returns>Redirection vers l'action Index après la création.</returns>
        [HttpPost]
        public IActionResult Commenter(Commentaire commentaire, int idTitre)
        {
            // Génération d'une liste de styles.
            var commentaires = this.commentaireRepository.FindCommentairesByIdTitre(idTitre);

            var titre = this.titreRepository.Find(idTitre);

            // Création du modèle de vue contenant un titre.
            var titreModel = new TitreModel
            {
                Titre = titre,
                Commentaires = commentaires,
            };

            if (!this.ModelState.IsValid)
            {
                // Traitement en cas de modèle non valide
                return this.View(titreModel);
            }

            commentaire.DateCreation = DateTime.Now;
            commentaire.Titre = titre;

            this.commentaireRepository.Add(commentaire);

            this.ModelState.Clear();

            return this.RedirectToAction(nameof(this.Index), new { idTitre });
        }
    }
}
