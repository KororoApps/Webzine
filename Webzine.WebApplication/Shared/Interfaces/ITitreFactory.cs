// <copyright file="ITitreFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Interfaces
{
    using System.Collections.Generic; // Assurez-vous d'avoir cette déclaration si elle manque
    using Webzine.Entity;

    /// <summary>
    /// Interface pour la classe TitreFactory, responsable de la création d'instances de la classe Titre.
    /// </summary>
    public interface ITitreFactory
    {
        /// <summary>
        /// Crée une nouvelle instance de la classe Titre avec des données générées.
        /// </summary>
        /// <returns>Une nouvelle instance de la classe Titre.</returns>
        Titre CreateTitre();

        /// <summary>
        /// Crée une collection de nouvelles instances de la classe Titre avec des données générées.
        /// </summary>
        /// <param name="random">Le nombre aléatoire de titres à générer.</param>
        /// <returns>Une collection de nouvelles instances de la classe Titre.</returns>
        IEnumerable<Titre> CreateTitres(int random);
    }
}
