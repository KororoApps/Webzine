// <copyright file="StyleModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Représente le modèle de vue pour un style.
    /// </summary>
    public class StyleModel
    {
        /// <summary>
        /// Obtient ou définit le style.
        /// </summary>
        public Style Style { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit une collection de styles.
        /// </summary>
        public IEnumerable<Style> Styles { get; set; } = new List<Style>();

        /// <summary>
        /// Obtient ou définit un le numéro de la page.
        /// </summary>
        public int NumeroPage { get; set; } = 0;
    }
}
