// <copyright file="IStyleFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Interfaces
{
    using System.Collections.Generic; // Assurez-vous d'avoir cette déclaration si elle manque
    using Webzine.Entity;

    /// <summary>
    /// Interface pour la classe StyleFactory, responsable de la création d'instances de la classe Style.
    /// </summary>
    public interface IStyleFactory
    {
        /// <summary>
        /// Crée une nouvelle instance de la classe Style avec des données générées.
        /// </summary>
        /// <returns>Une nouvelle instance de la classe Style.</returns>
        Style CreateStyle();

        /// <summary>
        /// Crée une collection de nouvelles instances de la classe Style avec des données générées.
        /// </summary>
        /// <param name="random">Le nombre aléatoire de styles à générer.</param>
        /// <returns>Une collection de nouvelles instances de la classe Style.</returns>
        IEnumerable<Style> CreateStyles(int random);
    }
}
