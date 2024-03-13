// <copyright file="CommentaireController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.WebApplication.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux commentaires dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des commentaires et leur suppression.
    /// Il utilise soit le générateur de fausses données Bogus pour simuler des données, soit des données Spotify en fonction du Seeder sélectionné.
    /// </remarks>
    /// <param name="commentaireRepository">Référence à la classe responsable de l'accès aux données des commentaires.</param>
    /// <param name="titreRepository">Référence à la classe responsable de l'accès aux données des titres.</param>
    [Area("Administration")]
    public class CommentaireController(ICommentaireRepository commentaireRepository, ITitreRepository titreRepository) : Controller
    {
        private readonly ICommentaireRepository commentaireRepository = commentaireRepository;
        private readonly ITitreRepository titreRepository = titreRepository;

        /// <summary>
        /// Action résultante permettant l'affichage de la liste des commentaires dans la zone d'administration.
        /// </summary>
        /// <param name="numeroPage">Le numéro de la page à afficher.</param>
        /// <returns>La vue avec la liste des commentaires.</returns>
        public IActionResult Index(int numeroPage)
        {
            var titreToSkip = numeroPage * 10;

            var commentaireModel = new CommentaireModel
            {
                Commentaires = this.commentaireRepository.FindCommentaires(titreToSkip, 10),
                NumeroPage = numeroPage,
            };

            return this.View(commentaireModel);
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
        public IActionResult Delete(Commentaire commentaire)
        {
            this.commentaireRepository.Delete(commentaire);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}