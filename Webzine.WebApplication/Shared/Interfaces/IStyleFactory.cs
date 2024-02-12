// <copyright file="IStyleFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Interfaces
{
    using Webzine.Entity;

    /// <summary>
    /// Interface for the StyleFactory class, responsible for creating instances of the Style class.
    /// </summary>
    public interface IStyleFactory
    {
        /// <summary>
        /// Creates a new instance of the Style class with generated data.
        /// </summary>
        /// <returns>A new instance of the Style class.</returns>
        Style CreateStyle();
    }
}