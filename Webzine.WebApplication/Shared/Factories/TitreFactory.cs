﻿// <copyright file="TitreFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
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
            this.fakerArtiste = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName());

            this.fakerCommentaire = new Faker<Commentaire>()
                .RuleFor(c => c.Auteur, f => f.Name.FullName())
                .RuleFor(c => c.Contenu, f => f.Lorem.Paragraph())
                .RuleFor(c => c.DateCreation, f => f.Date.Recent());

            this.fakerStyle = new Faker<Style>()
                .RuleFor(a => a.Libelle, f => this.CapitalizeFirstLetter(f.Lorem.Word()));

            // Générer la liste de styles en dehors de la règle principale
            var stylesList = this.fakerStyle.Generate(20);

            this.fakerTitre = new Faker<Titre>()
                .RuleFor(t => t.IdTitre, f => f.IndexFaker)
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Duree, f => f.Date.Timespan())
                .RuleFor(t => t.DateSortie, f => f.Date.Past())
                .RuleFor(t => t.NbLectures, f => f.Random.Number(1, 10000))
                .RuleFor(t => t.NbLikes, f => f.Random.Number(1, 1000))
                .RuleFor(t => t.Artiste, f => f.PickRandom(this.fakerArtiste.Generate(150)))
                .RuleFor(t => t.Commentaires, f => this.fakerCommentaire.Generate(f.Random.Number(1, 100)));
                //.RuleFor(t => t.Styles, f => f.PickRandom(this.fakerStyle.Generate(3)));
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
