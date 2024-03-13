// <copyright file="SeedDataLocal.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.EntitiesContext.Seeders
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.Entity.Fixtures;

    /// <summary>
    /// Classe statique pour initialiser les données de seed dans le context de la base de données.
    /// </summary>
    public static class SeedDataLocal
    {
        /// <summary>
        /// Initialise les données de seed dans le context de la base de données.
        /// </summary>
        /// <param name="context">Contexte de la base de données à initialiser.</param>
        public static void Initialize(WebzineDbContext context)
        {
            // Désactive le suivi des changements pour améliorer les performances lors du seeding.
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            // Ajoutez les ensembles de données au context.
            context.Artistes.AddRange(DataFactory.Artistes);
            context.Commentaires.AddRange(DataFactory.Commentaires);
            context.Styles.AddRange(DataFactory.Styles);
            context.Titres.AddRange(DataFactory.Titres);

            // Enregistrez les changements dans la base de donnée après le seeding.
            context.SaveChanges();
        }
    }
}