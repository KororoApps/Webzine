// <copyright file="TitreModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Représente le modèle de vue pour un titre.
    /// </summary>
    public class TitreModel
    {
        /// <summary>
        /// Obtient ou définit le titre.
        /// </summary>
        public Titre Titre { get; set; } = null!;
    }
}