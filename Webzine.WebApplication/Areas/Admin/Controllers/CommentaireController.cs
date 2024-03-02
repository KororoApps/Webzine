// <copyright file="CommentaireController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux commentaires dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des commentaires et leur suppression.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    [Area("Admin")]
    public class CommentaireController(ICommentaireRepository commentaireRepository, ITitreRepository titreRepository) : Controller
    {
        private readonly ICommentaireRepository commentaireRepository = commentaireRepository;
        private readonly ITitreRepository titreRepository = titreRepository;

        /// <summary>
        /// Action pour afficher la liste des commentaires.
        /// </summary>
        /// <returns>Vue contenant la liste des commentaires.</returns>
        public IActionResult Index()
        {
            // Création du modèle de vue contenant la liste de Commentaires.
            var commentaireModel = new GroupeCommentaireModel
            {
                Commentaires = this.commentaireRepository.FindAll(),
            };

            // Retour de la vue avec le modèle de vue contenant les commentaires générés.
            return this.View(commentaireModel);
        }

        /// <summary>
        /// Action pour afficher la vue de création d'un artiste.
        /// </summary>
        /// <param name="commentaire">L'entité Commentaire à créer</param>
        /// <param name="IdTitre">Id du titre lié au commentaire</param>
        /// <returns>Vue de création d'un artiste.</returns>
        public IActionResult Create(Commentaire commentaire, int IdTitre)
        {
            /*if (!this.ModelState.IsValid)
            {
                // Traitement en cas de modèle non valide
                return this.RedirectToAction(nameof(this.Create));
            }*/

            Titre titre = this.titreRepository.Find(IdTitre);

            Console.WriteLine(commentaire.Auteur);
            commentaire.DateCreation = DateTime.Now;
            commentaire.Titre = titre;

            this.commentaireRepository.Add(commentaire);
            return this.RedirectToAction("Index", "Commentaire", new { area = "Admin"});
        }

        /// <summary>
        /// Action pour afficher la vue de suppression d'un commentaire.
        /// </summary>
        /// <param name="id">L'identifiant du commentaire à supprimer.</param>
        /// <returns>Vue de suppression d'un commentaire.</returns>
        public IActionResult Delete(int id)
        {
            // Création du modèle de vue contenant un commentaire.
            var commentaireModel = new CommentaireModel
            {
                Commentaire = this.commentaireRepository.Find(id),
            };

            // Retour de la vue avec le modèle de vue contenant le commentaire généré.
            return this.View(commentaireModel);
        }

        /// <summary>
        /// Action HTTP POST pour confirmer la suppression d'un commentaire.
        /// </summary>
        /// <param name="id">L'identifiant du commentaire à supprimer.</param>
        /// <returns>Redirection vers l'action Index après la suppression.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            this.commentaireRepository.Delete(this.commentaireRepository.Find(id));
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}