// <copyright file="GroupeTitreModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Représente un groupe de titres dans le modèle de vue.
    /// </summary>
    public class GroupeTitreModel
    {
        /// <summary>
        /// Obtient ou définit la liste des titres dans le groupe.
        /// </summary>
        public IEnumerable<Titre> Titres { get; set; } = new List<Titre>();

        /// <summary>
        /// Obtient ou définit la liste des titres les plus populaires dans le groupe.
        /// </summary>
        public IEnumerable<Titre> TitresPopulaires { get; set; } = new List<Titre>();

        /// <summary>
        /// Obtient ou définit la liste des titres du plus récent au plus ancien chroniqué.
        /// </summary>
        public IEnumerable<Titre> ParutionChroniqueTitre { get; set; } = new List<Titre>();

        /// <summary>
        /// Obtient ou définit le terme de recherche saisi dans le formulaire.
        /// </summary>
        public string? Recherche { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des artistes dans le groupe.
        /// </summary>
        public List<Artiste>? Artistes { get; set; } = [];

        /// <summary>
        /// Obtient ou définit un style dans le groupe.
        /// </summary>
        public string? Libelle { get; set; }
    }
}
