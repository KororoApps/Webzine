// <copyright file="TitreFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Factories
{
    using Bogus;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.Interfaces;

    /// <summary>
    /// Classe de fabrique pour la création d'instances de la classe Titre avec des données générées.
    /// </summary>
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="TitreFactory"/>.
    /// </remarks>
    /// <param name="artisteFactory">Fabrique d'artistes utilisée pour générer des données d'artiste.</param>
    /// <param name="commentaireFactory">Fabrique de commentaires utilisée pour générer des données d'artiste.</param>
    /// <param name="styleFactory">Fabrique de styles utilisée pour générer des données d'artiste.</param>
    public class TitreFactory : ITitreFactory
    {
        private readonly Faker<Titre> fakerTitre;
        private readonly Faker<Artiste> fakerArtiste;
        private readonly Faker<Commentaire> fakerCommentaire;
        private readonly Faker<Style> fakerStyle;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TitreFactory"/>.
        /// </summary>
        public TitreFactory()
        {
            /// <summary>
            /// Configuration pour la génération de fausses données pour la classe Artiste.
            /// </summary>
            this.fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName())
                .RuleFor(a => a.Biographie, (f, u) => f.Lorem.Paragraph());

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Commentaire.
            /// <summary>
            this.fakerCommentaire = new Faker<Commentaire>()
                .RuleFor(c => c.Auteur, f => f.Name.FullName())
                .RuleFor(c => c.Contenu, f => f.Lorem.Paragraph())
                .RuleFor(c => c.DateCreation, f => f.Date.Recent())
                .RuleFor(a => a.Artiste, f => this.fakerArtiste.Generate());

            /// <summary>
            /// Configuration pour la génération de fausses données pour la classe Style.
            /// <summary>
            this.fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => this.CapitalizeFirstLetter(f.Lorem.Word()));

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            this.fakerTitre = new Faker<Titre>()
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Duree, f => f.Date.Timespan())
                .RuleFor(t => t.DateSortie, f => f.Date.Past())
                .RuleFor(t => t.DateCreation, f => f.Date.Recent())
                .RuleFor(t => t.NbLectures, f => f.Random.Number(1, 10000))
                .RuleFor(t => t.NbLikes, f => f.Random.Number(1, 1000))
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                .RuleFor(t => t.Chronique, f => f.Lorem.Paragraphs(10))
                .RuleFor(t => t.UrlJaquette, f => f.Image.PicsumUrl().ToString())
                .RuleFor(t => t.UrlEcoute, f => f.Internet.Url())
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                .RuleFor(a => a.Artiste, f => this.fakerArtiste.Generate())
                .RuleFor(c => c.Commentaires, f => this.fakerCommentaire.Generate(f.Random.Number(1, 7)))
                .RuleFor(s => s.Styles, f => this.fakerStyle.Generate(17));
    }

        /// <summary>
        /// Crée une instance de la classe Titre avec des données générées.
        /// </summary>
        /// <returns>Instance de la classe Titre créée.</returns>
        public Titre CreateTitre()
        {
            return this.fakerTitre.Generate();
        }

        /// <summary>
        /// Crée une liste de titres avec des données générées.
        /// </summary>
        /// <param name="count">Le nombre de titre à générer.</param>
        /// <returns>Une liste de titre générés.</returns>
        public List<Titre> CreateTitres(int count)
        {
            return this.fakerTitre.Generate(count);
        }

        /// <summary>
        /// Met la première lettre d'une chaîne en majuscule.
        /// </summary>
        /// <param name="input">La chaîne à traiter.</param>
        /// <returns>La chaîne avec la première lettre en majuscule.</returns>

        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }
    }
}
