// <copyright file="CommentaireController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Entity.Fixtures;
    using Webzine.WebApplication.Shared.ViewModels;

    /// <summary>
    /// Contrôleur responsable de la gestion des opérations liées aux commentaires dans la zone d'administration.
    /// </summary>
    /// <remarks>
    /// Ce contrôleur gère l'affichage de la liste des commentaires et leur suppression.
    /// Il utilise le générateur de fausses données Bogus pour simuler des données.
    /// </remarks>
    [Area("Admin")]
    public class CommentaireController : Controller
    {
        /// <summary>
        /// Action pour afficher la liste des commentaires.
        /// </summary>
        /// <returns>Vue contenant la liste des commentaires.</returns>
        public IActionResult Index()
        {
            /// <summary>
            /// Génération d'un commentaire.
            /// <summary>
            List<Commentaire> commentaires = DataFactory.Commentaires;

            /// <summary>
            /// Tri de la liste des commentaires par date de création.
            /// <summary>
            var commentairesTries = commentaires.OrderByDescending(c => c.DateCreation).ToList();

            /// <summary>
            /// Création du modèle de vue contenant la liste de Commentaires.
            /// <summary>
            var commentaireModel = new GroupeCommentaireModel
            {
                Commentaires = commentairesTries,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les commentaires générés.
            /// <summary>
            return this.View(commentaireModel);
        }

        /// <summary>
        /// Action pour afficher la vue de suppression d'un commentaire.
        /// </summary>
        /// <returns>Vue de suppression d'un commentaire.</returns>
        public IActionResult Delete()
        {
            /// <summary>
            /// Génération d'un commentaire.
            /// <summary>
            List<Commentaire> commentaires = DataFactory.Commentaires;
            Commentaire commentaire = commentaires.OrderBy(t => Guid.NewGuid()).FirstOrDefault();


            /// <summary>
            /// Création du modèle de vue contenant un commentaire.
            /// <summary>
            var commentaireModel = new CommentaireModel
            {
                Commentaire = commentaire,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant le commentaire généré.
            /// <summary>
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
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}