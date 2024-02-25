// <copyright file="DataFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Entity.Fixtures
{
    using Bogus;

    /// <summary>
    /// Classe statique pour générer des données fictives avec Bogus pour les entités du projet.
    /// </summary>
    public static class DataFactory
    {
        /// <summary>
        /// Instance statique de la classe Random pour la génération de nombres aléatoires.
        /// </summary>
        private static readonly Random Random = new();

        /// <summary>
        /// Génère une liste de styles fictifs.
        /// </summary>
        /// <param name="count">Nombre de styles à générer.</param>
        /// <returns>Liste de styles fictifs.</returns>
        public static List<Style> GenerateFakeStyles(int count)
        {
            var styleFaker = new Faker<Style>()
                .RuleFor(s => s.Libelle, f => f.Lorem.Word());

            return styleFaker.Generate(count);
        }

        /// <summary>
        /// Génère une liste de commentaires fictifs pour un titre donné.
        /// </summary>
        /// <param name="count">Nombre de commentaires à générer.</param>
        /// <param name="titre">Titre associé aux commentaires.</param>
        /// <returns>Liste de commentaires fictifs.</returns>
        public static List<Commentaire> GenerateFakeCommentaires(int count, Titre titre)
        {
            var commentaireFaker = new Faker<Commentaire>()
                .RuleFor(c => c.Auteur, f => f.Name.FullName())
                .RuleFor(c => c.Contenu, f => f.Lorem.Sentence())
                .RuleFor(c => c.DateCreation, f => f.Date.Past())
                .RuleFor(t => t.Titre, f => titre);

            return commentaireFaker.Generate(count);
        }

        /// <summary>
        /// Génère une liste d'artistes fictifs.
        /// </summary>
        /// <param name="count">Nombre d'artistes à générer.</param>
        /// <returns>Liste d'artistes fictifs.</returns>
        public static List<Artiste> GenerateFakeArtiste(int count)
        {
            var artisteFaker = new Faker<Artiste>()
                .RuleFor(a => a.Nom, f => f.Name.FullName())
                .RuleFor(a => a.Biographie, f => f.Lorem.Paragraph());

            var artistes = artisteFaker.Generate(count);

            foreach (var artiste in artistes)
            {
                /// <summary>
                /// Générer des titres pour chaque artiste.
                /// </summary>
                artiste.Titres = DataFactory.GenerateFakeTitres(Random.Next(1, 10), artiste);
            }

            return artistes;
        }

        /// <summary>
        /// Génère une liste de titres fictifs.
        /// </summary>
        /// <param name="count">Nombre de titres à générer.</param>
        /// <param name="artiste">Artiste associé aux titres.</param>
        /// <returns>Liste de titres fictifs.</returns>
        public static List<Titre> GenerateFakeTitres(int count, Artiste artiste)
        {
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Duree, f => f.Date.Timespan())
                .RuleFor(t => t.DateSortie, f => f.Date.Past())
                .RuleFor(t => t.DateCreation, f => f.Date.Past())
                .RuleFor(t => t.NbLectures, f => f.Random.Number(1, 10000))
                .RuleFor(t => t.NbLikes, f => f.Random.Number(1, 1000))
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                .RuleFor(t => t.Chronique, f => f.Lorem.Paragraphs(10))
                .RuleFor(t => t.UrlJaquette, f => f.Image.PicsumUrl().ToString())
                .RuleFor(t => t.UrlEcoute, f => f.Internet.Url())
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                .RuleFor(t => t.Artiste, f => artiste)
                .RuleFor(t => t.Styles, f => DataFactory.GenerateFakeStyles(Random.Next(1, 3)));

            var titres = titreFaker.Generate(count);

            foreach (var titre in titres)
            {
                /// <summary>
                /// Générer des commentaires pour chaque titre.
                /// </summary>
                titre.Commentaires = DataFactory.GenerateFakeCommentaires(Random.Next(1, 30), titre);
            }

            return titres;
        }
    }
}
