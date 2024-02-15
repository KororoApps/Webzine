// <copyright file="ICommentaireFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Interfaces
{
    using System.Collections.Generic; // Assurez-vous d'avoir cette déclaration si elle manque
    using Webzine.Entity;

    /// <summary>
    /// Interface pour la classe CommentaireFactory, responsable de la création d'instances de la classe Commentaire.
    /// </summary>
    public interface ICommentaireFactory
    {
        /// <summary>
        /// Crée une nouvelle instance de la classe Commentaire avec des données générées.
        /// </summary>
        /// <returns>Une nouvelle instance de la classe Commentaire.</returns>
        Commentaire CreateCommentaire();

        /// <summary>
        /// Crée une collection de nouvelles instances de la classe Commentaire avec des données générées.
        /// </summary>
        /// <param name="random">Le nombre aléatoire de commentaires à générer.</param>
        /// <returns>Une collection de nouvelles instances de la classe Commentaire.</returns>
        List<Commentaire> CreateCommentaires(int random);
    }
}
