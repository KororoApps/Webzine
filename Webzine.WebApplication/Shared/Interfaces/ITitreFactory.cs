// <copyright file="ITitreFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Interfaces
{
    using Webzine.Entity;

    /// <summary>
    /// Interface for the TitreFactory class, responsible for creating instances of the Titre class.
    /// </summary>
    public interface ITitreFactory
    {
        /// <summary>
        /// Creates a new instance of the Titre class with generated data.
        /// </summary>
        /// <returns>A new instance of the Titre class.</returns>
        Titre CreateTitre();
    }
}