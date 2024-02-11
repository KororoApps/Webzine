// <copyright file="GroupeArtisteModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Modèle de vue pour un groupe d'artistes.
    /// </summary>
    public class GroupeArtisteModel
    {
        /// <summary>
        /// Obtient ou définit un groupe de d'artistes.
        /// </summary>
        public IEnumerable<Artiste> Artistes { get; set; } = new List<Artiste>();
    }
}
