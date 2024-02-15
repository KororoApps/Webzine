﻿// <copyright file="CommentaireFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
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
    /// <remarks>
    /// Initialise une nouvelle instance de la classe <see cref="CommentaireFactory"/>.
    /// </remarks>
    public class CommentaireFactory : ICommentaireFactory
    {
        private readonly Faker<Titre> fakerTitre;
        private readonly Faker<Artiste> fakerArtiste;
        private readonly Faker<Commentaire> fakerCommentaire;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CommentaireFactory"/>.
        /// </summary>
        public CommentaireFactory()
        {
            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Titre.
            /// <summary>
            this.fakerTitre = new Faker<Titre>()
                .RuleFor(t => t.Libelle, f => f.Name.FullName());

            /// <summary>
            /// Configuration pour la génération de fausses données pour la classe Artiste.
            /// </summary>
            this.fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName());

            /// <summary>
            /// Configuration du générateur de fausses données pour la classe Commentaire.
            /// <summary>
            this.fakerCommentaire = new Faker<Commentaire>()
                .RuleFor(c => c.Auteur, f => f.Name.FullName())
                .RuleFor(c => c.Contenu, f => f.Lorem.Paragraph())
                .RuleFor(c => c.DateCreation, f => f.Date.Recent())
                .RuleFor(a => a.Artiste, f => this.fakerArtiste.Generate())
                .RuleFor(t => t.Titre, f => this.fakerTitre.Generate());
        }

        /// <summary>
        /// Crée une instance de la classe Commentaire avec des données générées.
        /// </summary>
        /// <returns>Instance de la classe Commentaire créée.</returns>
        public Commentaire CreateCommentaire()
        {
            return this.fakerCommentaire.Generate();
        }

        /// <summary>
        /// Crée une collection d'instances de la classe Commentaire avec des données générées.
        /// </summary>
        /// <param name="random">Le nombre aléatoire de commentaires à générer.</param>
        /// <returns>Une collection d'instances de la classe Commentaire.</returns>
        public List<Commentaire> CreateCommentaires(int random)
        {
            return this.fakerCommentaire.Generate(random);
        }
    }
}
