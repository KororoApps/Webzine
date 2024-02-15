// <copyright file="CommentaireController.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.Factories;
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
        private readonly CommentaireFactory commentaireFactory;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CommentaireController"/>.
        /// </summary>
        public CommentaireController()
        {
            this.commentaireFactory = new CommentaireFactory();
        }

        /// <summary>
        /// Action pour afficher la liste des commentaires.
        /// </summary>
        /// <returns>Vue contenant la liste des commentaires.</returns>
        public IActionResult Index()
        {
            var commentaires = this.commentaireFactory.CreateCommentaires(20);

            /// <summary>
            /// Création du modèle de vue contenant la liste de Commentaires.
            /// <summary>
            var commentaireModel = new GroupeCommentaireModel
            {
                Commentaires = commentaires,
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
            Commentaire commentaire = this.commentaireFactory.CreateCommentaire();

            /// <summary>
            /// Création du modèle de vue contenant un commentaire.
            /// <summary>
            var commentaireModel = new CommentaireModel
            {
                Commentaire = commentaire,
            };

            /// <summary>
            /// Retour de la vue avec le modèle de vue contenant les commentaires générés.
            /// <summary>
            return this.View(commentaireModel);
        }
    }
}