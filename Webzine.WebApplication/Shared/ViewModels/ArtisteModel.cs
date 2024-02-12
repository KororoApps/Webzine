// <copyright file="ArtisteModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Modèle de vue pour un artiste.
    /// </summary>
    public class ArtisteModel
    {
        /// <summary>
        /// Obtient ou définit l'artiste.
        /// </summary>
        public Artiste Artiste { get; set; } = null!;

    }
}
