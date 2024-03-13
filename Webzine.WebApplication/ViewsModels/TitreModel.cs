// <copyright file="TitreModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.ViewModels
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
        /// Obtient ou définit la liste des titres dans le groupe.
        /// </summary>
        public IEnumerable<Titre> Titres { get; set; } = new List<Titre>();

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
        public IEnumerable<Artiste>? Artistes { get; set; } = [];

        /// <summary>
        /// Obtient ou définit les commentaires.
        /// </summary>
        public IEnumerable<Commentaire>? Commentaires { get; set; }

        /// <summary>
        /// Obtient ou définit l'artiste.
        /// </summary>
        public Artiste? Artiste { get; set; }

        /// <summary>
        /// Obtient ou définit une liste de styles.
        /// </summary>
        public IEnumerable<Style>? StylesIds { get; set; } = [];

        /// <summary>
        /// Obtient ou définit la liste des titres les plus populaires dans le groupe.
        /// </summary>
        public IEnumerable<Titre> TitresPopulaires { get; set; } = new List<Titre>();

        /// <summary>
        /// Obtient ou définit la liste des titres du plus récent au plus ancien chroniqué.
        /// </summary>
        public IEnumerable<Titre> ParutionChroniqueTitre { get; set; } = new List<Titre>();

        /// <summary>
        /// Obtient ou définit un style dans le groupe.
        /// </summary>
        public string? Libelle { get; set; }

        /// <summary>
        /// Obtient ou définit un le numéro de la page.
        /// </summary>
        public int NumeroPage { get; set; } = 0;

        /// <summary>
        /// Obtient ou définit un la longueur de la chronique en page d'accueil.
        /// </summary>
        public int MaxDescriptionTitre { get; set; }
    }
}