// <copyright file="GroupeStyleModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Représente le modèle de vue pour un groupe de styles.
    /// </summary>
    public class GroupeStyleModel
    {
        /// <summary>
        /// Obtient ou définit une collection de styles.
        /// </summary>
        public IEnumerable<Style> Styles { get; set; } = new List<Style>();
    }
}
