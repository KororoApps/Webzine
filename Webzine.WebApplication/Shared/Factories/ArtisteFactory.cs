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
    /// 
    public class ArtisteFactory : IArtisteFactory
    {
        private readonly Faker<Titre> fakerTitre;
        private readonly Faker<Artiste> fakerArtiste;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ArtisteFactory"/>.
        /// </summary>
        public ArtisteFactory()
        {
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            this.fakerTitre = new Faker<Titre>()
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Duree, f => f.Date.Timespan())
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                .RuleFor(t => t.UrlJaquette, f => f.Image.PicsumUrl().ToString())
                .RuleFor(t => t.Album, f => f.Commerce.ProductName());

            /// <summary>
            /// Configuration pour la génération de fausses données pour la classe Artiste.
            /// </summary>
            this.fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName())
                .RuleFor(a => a.Biographie, (f, u) => f.Lorem.Paragraph())
                .RuleFor(t => t.Titres, f => this.fakerTitre.Generate(f.Random.Number(1, 100)));
        }

        /// <summary>
        /// Crée une nouvelle instance de la classe Artiste avec des données générées.
        /// </summary>
        /// <returns>Une nouvelle instance de la classe Artiste.</returns>
        public Artiste CreateArtiste()
        {
            return this.fakerArtiste.Generate();
        }

        /// <summary>
        /// Crée une liste d'artistes avec des données générées.
        /// </summary>
        /// <param name="count">Le nombre d'artistes à générer.</param>
        /// <returns>Une liste d'artistes générés.</returns>
        public List<Artiste> CreateArtistes(int count)
        {
            return this.fakerArtiste.Generate(count);
        }
    }
}