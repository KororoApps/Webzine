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
    }
}
