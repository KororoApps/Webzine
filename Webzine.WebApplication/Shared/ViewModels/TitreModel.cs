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

        /// <summary>
        /// Obtient ou définit les styles.
        /// </summary>
        public IEnumerable<Style>? Styles { get; set; }

        /// <summary>
        /// Obtient ou définit un commentaire.
        /// </summary>
        public Commentaire? Commentaire { get; set; }

        /// <summary>
        /// Obtient ou définit les artistes.
        /// </summary>
        public IEnumerable<Artiste> Artistes { get; set; }

        /// <summary>
        /// Obtient ou définit les commentaires.
        /// </summary>
        public IEnumerable<Commentaire>? Commentaires { get; set; }

        /// <summary>
        /// Obtient ou définit l'artiste.
        /// </summary>
        public Artiste Artiste { get; set; }
    }
}