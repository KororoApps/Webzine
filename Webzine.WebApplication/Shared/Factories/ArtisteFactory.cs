// <copyright file="ArtisteFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Factories
{
    using Bogus;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.Interfaces;

    /// <summary>
    /// Classe de fabrique pour la création d'instances de la classe Artiste avec des données générées.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="ArtisteFactory"/>.
    /// </remarks>
    /// <param name="titreFactory">Fabrique de titres utilisée pour générer des données de titre.</param>
    public class ArtisteFactory(ITitreFactory titreFactory)
    {
        /// <summary>
        /// Configuration pour la génération de fausses données pour la classe Artiste.
        /// </summary>
        private readonly Faker<Artiste> fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName())
                .RuleFor(a => a.Biographie, (f, u) => f.Lorem.Paragraph())
                .RuleFor(t => t.Titres, f => titreFactory.CreateTitres(f.Random.Number(1, 10)));

        /// <summary>
        /// Crée une nouvelle instance de la classe Artiste avec des données générées.
        /// </summary>
        /// <returns>Une nouvelle instance de la classe Artiste.</returns>
        public Artiste CreateArtiste()
        {
            return this.fakerArtiste.Generate();
        }
    }
}