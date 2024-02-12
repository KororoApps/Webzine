// <copyright file="CommentaireFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Shared.Factories
{
    using Bogus;
    using Webzine.Entity;
    using Webzine.WebApplication.Shared.Interfaces;

    /// <summary>
    /// Classe de fabrique pour la création d'instances de la classe Commentaire avec des données générées.
    /// </summary>
    public class CommentaireFactory : ICommentaireFactory
    {
        private readonly Faker<Commentaire> fakerCommentaire;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CommentaireFactory"/>.
        /// </summary>
        /// <param name="artisteFactory">Fabrique d'artistes utilisée pour générer des données d'artiste.</param>
        /// <param name="titreFactory">Fabrique de titres utilisée pour générer des données de titre.</param>
        public CommentaireFactory(IArtisteFactory artisteFactory, ITitreFactory titreFactory)
        {
            /// <summary>
            /// Configuration pour la génération de fausses données pour la classe Commentaire.
            /// </summary>
            this.fakerCommentaire = new Faker<Commentaire>()
                .RuleFor(c => c.Auteur, f => f.Name.FullName())
                .RuleFor(c => c.Contenu, f => f.Lorem.Paragraph())
                .RuleFor(c => c.DateCreation, f => f.Date.Recent())
                .RuleFor(t => t.Artiste, f => artisteFactory.CreateArtiste())
                .RuleFor(t => t.Titre, f => titreFactory.CreateTitre());
        }

        /// <summary>
        /// Crée une nouvelle instance de la classe Commentaire avec des données générées.
        /// </summary>
        /// <returns>Une nouvelle instance de la classe Commentaire.</returns>
        public Commentaire CreateCommentaire()
        {
            return this.fakerCommentaire.Generate();
        }
    }
}
