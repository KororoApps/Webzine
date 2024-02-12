// <copyright file="ICommentaireFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Interfaces
{
    using Webzine.Entity;

    /// <summary>
    /// Interface for the CommentaireFactory class, responsible for creating instances of the Commentaire class.
    /// </summary>
    public interface ICommentaireFactory
    {
        /// <summary>
        /// Creates a new instance of the Commentaire class with generated data.
        /// </summary>
        /// <returns>A new instance of the Commentaire class.</returns>
        Commentaire CreateCommentaire();
    }
}