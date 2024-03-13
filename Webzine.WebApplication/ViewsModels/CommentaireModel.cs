// <copyright file="CommentaireModel.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.ViewModels
{
    using Webzine.Entity;

    /// <summary>
    /// Modèle de vue pour un commentaire.
    /// </summary>
    public class CommentaireModel
    {
        /// <summary>
        /// Obtient ou définit le titre.
        /// </summary>
        public Commentaire Commentaire { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit la liste des commentaires associés au groupe.
        /// </summary>
        public IEnumerable<Commentaire> Commentaires { get; set; } = new List<Commentaire>();

        /// <summary>
        /// Obtient ou définit un le numéro de la page.
        /// </summary>
        public int NumeroPage { get; set; } = 0;
    }
}