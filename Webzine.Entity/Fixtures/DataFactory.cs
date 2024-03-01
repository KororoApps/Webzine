// <copyright file="DataFactory.cs" company="Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton">
// Copyright (c) Equipe 4 - Andgel Sassignol, Romain Vidotto, Jean-Emilien Viard, Lucas Fernandez, Dylann-Nick Etou Mbon, Antoine Couvert, Elodie Sponton. All rights reserved.
// </copyright>

namespace Webzine.Entity.Fixtures
{
    using Bogus;
    using Bogus.DataSets;

    /// <summary>
    /// Classe statique pour générer des données fictives avec Bogus pour les entités du projet.
    /// </summary>
    public static class DataFactory
    {
        // Initialise les listes d'entités
        static DataFactory()
        {
            Artistes = new List<Artiste>();
            Titres = new List<Titre>();
            Commentaires = new List<Commentaire>();
            Styles = new List<Style>();

            // Génère des données fictives pour les entités
            GenerateFakeArtiste();
            GenerateFakeStyles();           
            GenerateFakeTitres();
            GenerateFakeCommentaires();
        }

        /// <summary>
        /// Obtient ou définit liste d'artistes fictifs.
        /// </summary>
        public static List<Artiste> Artistes { get; set; }

        /// <summary>
        /// Obtient ou définit liste de styles fictifs.
        /// </summary>
        public static List<Style> Styles { get; set; }

        /// <summary>
        /// Obtient ou définit liste de titres fictifs.
        /// </summary>
        public static List<Titre> Titres { get; set; }

        /// <summary>
        /// Obtient ou définit liste de commentaires fictifs.
        /// </summary>
        public static List<Commentaire> Commentaires { get; set; }

        /// <summary>
        /// Génère une liste de styles fictifs.
        /// </summary>
        public static void GenerateFakeStyles()
        {
            var styleFaker = new Faker<Style>()
                .RuleFor(t => t.IdStyle, f => f.IndexFaker + 1)
                .RuleFor(s => s.Libelle, f => f.Music.Genre());

            Styles = styleFaker.Generate(18);

            // Assurer l'unicité des libellés
            var libellesUniques = new HashSet<string>();
            foreach (var style in Styles)
            {
                while (!libellesUniques.Add(style.Libelle))
                {
                    style.Libelle = styleFaker.Generate().Libelle;
                }
            }
        }


        /// <summary>
        /// Génère une liste d'artistes fictifs.
        /// </summary>
        public static void GenerateFakeArtiste()
        {
            var artisteFaker = new Faker<Artiste>()
                .RuleFor(t => t.IdArtiste, f => f.IndexFaker + 1)
                .RuleFor(a => a.Nom, f => f.Name.FullName())
                .RuleFor(a => a.Biographie, f => f.Lorem.Paragraph());


            Artistes = artisteFaker.Generate(300);
        }

        /// <summary>
        /// Génère une liste de titres fictifs.
        /// </summary>
        public static void GenerateFakeTitres()
        {
            var titreFaker = new Faker<Titre>()
                .RuleFor(t => t.IdTitre, f => f.IndexFaker + 1)
                .RuleFor(t => t.Libelle, f => f.Name.FullName())
                .RuleFor(t => t.Duree, f => f.Date.Timespan())
                .RuleFor(t => t.DateSortie, f => f.Date.Past().ToUniversalTime())
                .RuleFor(t => t.DateCreation, f => f.Date.Past().ToUniversalTime())
                .RuleFor(t => t.NbLectures, f => f.Random.Number(1, 10000))
                .RuleFor(t => t.NbLikes, f => f.Random.Number(1, 1000))
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                .RuleFor(t => t.Chronique, f => f.Lorem.Paragraphs(10))
                .RuleFor(t => t.UrlJaquette, f => f.Image.PicsumUrl().ToString())
                .RuleFor(t => t.UrlEcoute, f => f.Internet.Url())
                .RuleFor(t => t.Album, f => f.Commerce.ProductName())
                .RuleFor(t => t.Artiste, f => f.PickRandom(Artistes))
                //.RuleFor(t => t.Commentaires, f => f.PickRandom(Commentaires, 10).ToList())
                .RuleFor(t => t.Styles, f => f.PickRandom(Styles, 15).ToList());

            Titres = titreFaker.Generate(400);

        }
        /// <summary>
        /// Génère une liste de commentaires fictifs.
        /// </summary>
        public static void GenerateFakeCommentaires()
        {
            var commentaireFaker = new Faker<Commentaire>()
                .RuleFor(c => c.IdCommentaire, f => f.IndexFaker + 1)
                .RuleFor(c => c.Auteur, f => f.Name.FullName())
                .RuleFor(c => c.Contenu, f => f.Lorem.Sentence())
                .RuleFor(c => c.DateCreation, f => f.Date.Past().ToUniversalTime())
                .RuleFor(c => c.Titre, f => f.PickRandom(Titres));

            Commentaires = commentaireFaker.Generate(1000);
        }
    }
}
