// <copyright file="CommentaireModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Modèle de vue pour un commentaire.
    /// </summary>
    public class CommentaireModel
    {
        /// <summary>
        /// Obtient ou définit le titre.
        /// </summary>
        public Commentaire Commentaire { get; set; } = null!;
    }
}