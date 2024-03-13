// <copyright file="ArtisteModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Représente le modèle de tableau de bord avec des statistiques liées aux artistes, titres et styles.
    /// </summary>
    public class DashboardModel
    {
        /// <summary>
        /// Obtient ou définit le nombre total d'artistes.
        /// </summary>
        public int NbArtistes { get; set; }

        /// <summary>
        /// Obtient ou définit l'artiste ayant le plus grand nombre de chroniques.
        /// </summary>
        public Artiste? ArtistePlusChronique { get; set; }

        /// <summary>
        /// Obtient ou définit l'artiste ayant le plus grand nombre de titres.
        /// </summary>
        public Artiste? ArtistePlusDeTitres { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre total de biographies d'artistes disponibles.
        /// </summary>
        public int NbBioArtiste { get; set; }

        /// <summary>
        /// Obtient ou définit le titre le plus lu.
        /// </summary>
        public Titre? TitrePlusLu { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre total de titres.
        /// </summary>
        public int NbTitres { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre total de styles musicaux.
        /// </summary>
        public int NbStyles { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre total de lectures de titres.
        /// </summary>
        public int NbLectures { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre total de likes sur les titres.
        /// </summary>
        public int NbLikes { get; set; }
    }
}