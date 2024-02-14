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
        /// <param name="nombreStyles">Le nombre aléatoire de styles à générer.</param>
        /// <returns>Une nouvelle instance de la classe Titre.</returns>
        Titre CreateTitre(int nombreStyles);

        /// <summary>
        /// Crée une collection de nouvelles instances de la classe Titre avec des données générées.
        /// </summary>
        /// <param name="count">Le nombre aléatoire de titres à générer.</param>
        /// /// <param name="nombreStyles">Le nombre de styles à générer pour le Titre.</param>
        /// <returns>Une collection de nouvelles instances de la classe Titre.</returns>
        List<Titre> CreateTitres(int count, int nombreStyles);
    }
}
