// <copyright file="ArtisteModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Modèle de vue pour un artiste.
    /// </summary>
    public class RechercheModel
    {
        /// <summary>
        /// Obtient ou définit un groupe de d'artistes.
        /// </summary>
        public IEnumerable<Artiste> Artistes { get; set; } = new List<Artiste>();

        /// <summary>
        /// Obtient ou définit la liste des titres dans le groupe.
        /// </summary>
        public IEnumerable<Titre> Titres { get; set; } = new List<Titre>();

        /// <summary>
        /// Obtient ou définit le terme de recherche saisi dans le formulaire.
        /// </summary>
        public string? Recherche { get; set; }
    }
}
