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
    public class TitreFactory(IArtisteFactory artisteFactory, ICommentaireFactory commentaireFactory, IStyleFactory styleFactory)
    {
        private readonly Faker<Titre> fakerTitre = new Faker<Titre>()
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Duree, f => f.Date.Timespan())
                .RuleFor(t => t.DateSortie, f => f.Date.Past())
                .RuleFor(t => t.NbLectures, f => f.Random.Number(1, 10000))
                .RuleFor(t => t.NbLikes, f => f.Random.Number(1, 1000))
                .RuleFor(a => a.Artiste, f => artisteFactory.CreateArtiste())
                .RuleFor(c => c.Commentaires, f => commentaireFactory.CreateCommentaires(f.Random.Number(1, 10)))
                .RuleFor(s => s.Styles, f => styleFactory.CreateStyles(f.Random.Number(1, 10)));

        /// <summary>
        /// Crée une instance de la classe Titre avec des données générées.
        /// </summary>
        /// <returns>Instance de la classe Titre créée.</returns>
        public Titre CreateTitre()
        {
            return this.fakerTitre.Generate();
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
