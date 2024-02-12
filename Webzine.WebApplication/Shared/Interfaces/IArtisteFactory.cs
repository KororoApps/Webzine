// <copyright file="IArtisteFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Interfaces
{
    using System.Collections.Generic; // Assurez-vous d'avoir cette déclaration si elle manque
    using Webzine.Entity;

    /// <summary>
    /// Interface pour la classe ArtisteFactory, responsable de la création d'instances de la classe Artiste.
    /// </summary>
    public interface IArtisteFactory
    {
        /// <summary>
        /// Crée une nouvelle instance de la classe Artiste avec des données générées.
        /// </summary>
        /// <returns>Une nouvelle instance de la classe Artiste.</returns>
        Artiste CreateArtiste();
    }
}